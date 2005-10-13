#include <list>
#include "../graph/MemoryManager.h"
#include "../SystemFunction/ISystemFunction.h"


class SegmentIterator : private MemoryManager
{
public:
	SegmentIterator(ISystemFunction* function, int history);
	virtual ~SegmentIterator(void);


private:
	struct Point {
		double* x;
		double* imageCache;
	};

	typedef list<Point> PointsList;
	

private:
	PointsList* pointsList;
	PointsList** historyList;


public:
	void Start(double* one, double* two);
	void Start(const char* file);
	void Iterate(const double* precision);

	void ExportToFile(const char* path);

private:
	ISystemFunction* function;
	double* input;
	double* output;
	const int dimension;
	const int history;

	int generation;

private:
	void SetInput(double* data);
	double* CopyArray(const double* data);

	Point CreatePoint(const double* data);

	Point Image(Point& p);

	bool isClose(const Point& p1, const Point& p2, const double* dist) const;

	double Abs(double x) const;

	Point Middle(const Point& p1, const Point& p2);
};
