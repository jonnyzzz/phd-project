#include "StdAfx.h"
#include ".\romadapter.h"
#include "..\cellImageBuilders\ProgressBarInfo.h"
#include "rom.h"

CRomAdapter::CRomAdapter(CRom* rom) : rom(rom)
{
}

CRomAdapter::~CRomAdapter(void)
{
	delete rom;
}



CRomResult  CRomAdapter::Compute(ProgressBarInfo* pinfo) {
	//todo: Implement pinfo calls

	rom->minimize();

	CRomResultValue left(rom->getAnswer(), rom->getAnswerLength());

	rom->maximize();

	CRomResultValue right(rom->getAnswer(), rom->getAnswerLength());

	return CRomResult(left, right);
}