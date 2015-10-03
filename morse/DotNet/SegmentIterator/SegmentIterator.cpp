#include "stdafx.h"
#include "SegmentIterator.h"

SegmentIterator::SegmentIterator(ISystemFunction* function, int history) : 
	MemoryManager(sizeof(double)*function->getDimension()*100000),
	function(function), 
	dimension(function->getDimension()),
	history(history),
	generation(0)
{
	input = function->getInput();
	output = function->getOutput();
	historyList = new PointsList*[history];
	for (int i=0; i<history; i++) {
		historyList[i] = NULL;
	}
	pointsList = new PointsList();
	historyList[generation++] = pointsList;
	if (generation >= history) generation = 0;
}

SegmentIterator::~SegmentIterator(void)
{	
	for (int i=0; i<history; i++) {
		delete historyList[i];
	}
	delete[] historyList;	
}


void SegmentIterator::SetInput(double* data) {
	memcpy(this->input, data, sizeof(double)*dimension);
}

double* SegmentIterator::CopyArray(const double* data) {
	double* myData = AllocateArray<double>(dimension);
	memcpy(myData, data, sizeof(double)*dimension);
	return myData;
}

SegmentIterator::Point SegmentIterator::CreatePoint(const double* data) {
	Point pt;
	pt.x = CopyArray(data);
	pt.imageCache = NULL;
	return pt;
}

void SegmentIterator::Start(double* one, double* two) {
	pointsList->clear();
	pointsList->push_back(CreatePoint(one));
	pointsList->push_back(CreatePoint(two));	
}

void SegmentIterator::Start(const char* file) {

	pointsList->clear();

	ifstream i;
	i.open(file);

	int cnt;
	i>>cnt;

	double* x = AllocateArray<double>(dimension);

	for (int cc=0; cc<cnt; cc++) {
		for (int c=0; c<dimension; c++) {
			i>>(x[c]);
		}

		pointsList->push_back(CreatePoint(x));
	}
	i.close();
}


SegmentIterator::Point SegmentIterator::Image(Point& p) {
	if (p.imageCache != NULL) {
		Point pt;
		pt.x = p.imageCache;
		pt.imageCache = NULL;
		return pt;
	} else {
		SetInput(p.x);
		function->evaluate();
 		Point pt = CreatePoint(CopyArray(output));
		p.imageCache = pt.x;
		return pt;
	}
}

bool SegmentIterator::isClose(const Point& p1, const Point& p2, const double* dist) const {
	for (int i=0; i<dimension; i++) {
		if (Abs(p1.x[i]-p2.x[i]) > dist[i]) return false;
	}
	return true;
}

double inline SegmentIterator::Abs(double x) const {
	return (x>0)?x:-x;
}

SegmentIterator::Point SegmentIterator::Middle(const Point& p1, const Point& p2) {
	double* data = AllocateArray<double>(dimension);
	for (int i=0; i<dimension; i++) {
		data[i] = (p1.x[i]+p2.x[i])/2;
	}
	Point pt;
	pt.x = data;
	pt.imageCache = NULL;

	return pt;
}

void SegmentIterator::Iterate(const double* prec) {
	if (generation >= history) generation = 0;

	PointsList* tempList = new PointsList();

	PointsList::iterator it_prev = pointsList->begin(); 
	PointsList::iterator it_cur = ++pointsList->begin(); 
	Point pt = Image(*it_prev);
	tempList->push_back(pt);
	
	while (it_cur != pointsList->end() ) {
		
		Point npt = Image(*it_cur);
	
		if  (!isClose(pt, npt, prec)) {					
			pointsList->insert(it_cur, Middle(*it_prev, *it_cur));			
			it_cur = it_prev;
			it_cur++;
		} else {
			pt = npt;
			tempList->push_back(npt);			
			it_prev = it_cur++;
		}
	}

	pointsList = tempList;
	
	if (historyList[generation] != NULL) {
		delete historyList[generation];
	}
	historyList[generation++] = tempList;

	if (generation >= history) generation = 0;

}


void SegmentIterator::ExportToFile(const char * file) {

	ofstream f;
	f.open(file);

	for (int g = 0; g<history; g++) {
		for (PointsList::iterator it=historyList[g]->begin(); it!=historyList[g]->end(); it++) {
			for (int i=0; i<dimension; i++) {
				f<<scientific<<it->x[i]<<" ";
			}
			f<<endl;
		}
	}

	f.close();
}

