#include "stdafx.h"
#include "SegmentIterator.h"

SegmentIterator::SegmentIterator(ISystemFunction* function) : 
	function(function),
	MemoryManager(sizeof(double)*function->getDimension()*100000),
	dimension(function->getDimension())
{
	input = function->getInput();
	output = function->getOutput();
}

SegmentIterator::~SegmentIterator(void)
{
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
	return pt;
}

void SegmentIterator::Start(double* one, double* two) {
	points.clear();
	points.push_back(CreatePoint(one));
	points.push_back(CreatePoint(two));
}

void SegmentIterator::Start(const char* file) {

	points.clear();

	ifstream i;
	i.open(file);

	int cnt;
	i>>cnt;

	double* x = AllocateArray<double>(dimension);

	for (int cc=0; cc<cnt; cc++) {
		for (int c=0; c<dimension; c++) {
			i>>(x[c]);
		}

		points.push_back(CreatePoint(x));
	}
	i.close();
}


SegmentIterator::Point SegmentIterator::Image(const Point& p) {
	SetInput(p.x);
	function->evaluate();
	return CreatePoint(CopyArray(output));
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

	return pt;
}

void SegmentIterator::Iterate(const double* prec) {
	PointsList tempList;

	PointsList::iterator it_prev = points.begin(); 
	PointsList::iterator it_cur = ++points.begin(); 
	Point pt = Image(*it_prev);
	
	for (; it_cur != points.end(); ) {
		
		Point npt = Image(*it_cur);
	
		if  (!isClose(pt, npt, prec)) {					
			points.insert(it_cur, Middle(*it_prev, *it_cur));			
			it_cur = it_prev;
			it_cur++;
			//goto reset;	
		} else {
			pt = npt;
			tempList.push_back(npt);			
			it_prev = it_cur++;
		}
	}

	points = tempList;

	for (PointsList::iterator it=points.begin(); it!=points.end(); it++) {
		history.push_back(*it);
	}
}


void SegmentIterator::ExportToFile(const char * file) {

	ofstream f;
	f.open(file);

	for (PointsList::iterator it=history.begin(); it!=history.end(); it++) {
		for (int i=0; i<dimension; i++) {
			f<<scientific<<it->x[i]<<" ";
		}
		f<<endl;
	}

	f.close();
}

