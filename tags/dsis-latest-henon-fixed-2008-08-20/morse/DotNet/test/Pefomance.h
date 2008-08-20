#pragma once

#include <time.h>
#include <list>

typedef pair<int, int> int2;
typedef list<int2> stat_t; 

class Pefomance
{
public:
	Pefomance(void);
	~Pefomance(void);

public:
	stat_t stat;

	int2 getAvg();

	void dimpStat();


public:

	void test();

	void test2();

	//time_t testPoint(JInt* factor, JInt* ks);
	//time_t testTaylor(JInt* factor);
};
