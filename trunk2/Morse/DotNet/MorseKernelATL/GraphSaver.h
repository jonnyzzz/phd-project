#pragma once

class Graph;

class GraphSaver
{
public:
	GraphSaver(void);
	~GraphSaver(void);

public:
	HRESULT SaveGraphToFile(Graph* graph, CString fileName);
	HRESULT SaveGraphToFile(GraphComponents* cms, CString fileName);


private:
	bool openFile(CString file, ofstream& o);
	void AppendGraphToString(Graph* graph, CString& out); 

};
