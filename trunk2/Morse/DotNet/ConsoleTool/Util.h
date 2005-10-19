#include "../cellImageBuilders/GraphSet.h"

class Graph;


class Util
{
public:
	
	static void SaveGraphSet(GraphSet set, char* file);
	static GraphSet LoadGraphSet(char* file);
	static void ExportPoints(GraphSet set, const char* file, const char* path="");

	static void RawerPoints(const char* inFile, const char* outFile, const int* grid, int dim);
};
