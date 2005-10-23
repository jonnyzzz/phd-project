#include "../cellImageBuilders/GraphSet.h"

class Graph;


class Util
{
public:
	
	static void SaveGraphSet(GraphSet set, char* file);
	static GraphSet LoadGraphSet(char* file, bool loadEdges = true);
	static void ExportPoints(GraphSet set, const char* file, const char* path="", const char* title="");

	static void RawerPoints(const char* inFile, const char* outFile, const int* grid, int dim);
};
