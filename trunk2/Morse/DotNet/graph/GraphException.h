
enum GraphExceptionType {
	GraphException_NoSuchResult,
	GraphException_NoParameters,
	GraphException_NoImplementation,
};


class GraphException
{
public:
	GraphException(GraphExceptionType type);
	//GraphException(GraphException& ex);
	~GraphException(void);

};

