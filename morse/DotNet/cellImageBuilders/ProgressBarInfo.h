
#ifndef _CELLIMAGEBUILDERS_PROGRASSBARINFO_H
#define _CELLIMAGEBUILDERS_PROGRASSBARINFO_H

class ProgressBarInfo
{
public:
	ProgressBarInfo();
	virtual ~ProgressBarInfo();
public:
	virtual double Length() = 0;	
	virtual void Advance(double length) = 0;
	virtual void Stop() = 0;
	virtual bool NeedStop() = 0;

	virtual void Start() = 0;
};

class DevidedProgressBarInfo : public ProgressBarInfo {
private:
	ProgressBarInfo* pinfo;
	double factor;
	int starts;
public:
	DevidedProgressBarInfo(ProgressBarInfo* pinfo, double factor) : pinfo(pinfo), factor(factor), starts(0) {}
	virtual ~DevidedProgressBarInfo() {}

public:
	virtual double Length() {return pinfo->Length() / factor; }	
	virtual void Advance(double length) { pinfo->Advance(length); }
	virtual void Stop() {pinfo->Stop(); }
	virtual bool NeedStop() { return pinfo->NeedStop(); }
	virtual void Start() { if (starts++ == 0) pinfo->Start(); }
};



class ProgressBarAdapter {
private:
	double cnt;
	double step;
	ProgressBarInfo* pinfo;

public:
	ProgressBarAdapter(ProgressBarInfo* pinfo, double units);
	~ProgressBarAdapter();

public:
	bool Next();
};



#endif //_CELLIMAGEBUILDERS_PROGRASSBARINFO_H
