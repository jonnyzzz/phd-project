#pragma once

#include "../cellImageBuilders/GraphSet.h"

class Graph;


class Util
{
public:
	
	static void SaveGraphSet(GraphSet set, char* file);
	static GraphSet LoadGraphSet(char* file);
};
