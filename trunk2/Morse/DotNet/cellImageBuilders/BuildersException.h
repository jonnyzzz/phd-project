#pragma once

enum BuildersExceptionEnum {
	BuildersException_Wrong_Dimension,
};

class BuildersException
{
public:
	BuildersException(BuildersExceptionEnum);
	virtual ~BuildersException(void);
};
