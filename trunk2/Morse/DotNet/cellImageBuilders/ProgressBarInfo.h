
#ifndef _CELLIMAGEBUILDERS_PROGRASSBARINFO_H
#define _CELLIMAGEBUILDERS_PROGRASSBARINFO_H

class ProgressBarInfo
{
public:
	ProgressBarInfo();
	virtual ~ProgressBarInfo();
public:
	virtual int Length();
	virtual void Next();
	virtual void Next(int length);
	virtual bool NeedStop();
};


#endif //_CELLIMAGEBUILDERS_PROGRASSBARINFO_H
