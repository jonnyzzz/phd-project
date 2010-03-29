#pragma once

class Graph;
class FileOutputStream;

class GraphSaver
{
public:
	GraphSaver(void);
	~GraphSaver(void);

public:
	HRESULT SaveGraphToFile(Graph* graph, CString fileName);
	HRESULT SaveGraphToFile(GraphComponents* cms, CString fileName);


private:
	void SaveGraph(Graph* graph, FileOutputStream& o);
};
