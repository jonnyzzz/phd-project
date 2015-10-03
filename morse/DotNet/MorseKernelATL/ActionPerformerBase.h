#pragma once

#include "nodebase.h"

class ProgressBarInfo;

class ActionPerformerBase
{
public:
	ActionPerformerBase(void);
	~ActionPerformerBase(void);


public:
	ProgressBarInfo* CreateProgressBarInfo(IParams* params);

};
