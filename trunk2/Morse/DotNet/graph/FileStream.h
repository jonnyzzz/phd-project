// FileStream.h: interface for the FileStream class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_FILESTREAM_H__CB141271_52FB_4D49_8029_013749B3CDC2__INCLUDED_)
#define AFX_FILESTREAM_H__CB141271_52FB_4D49_8029_013749B3CDC2__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream>
#include <fstream>

using namespace std;

class FileInputStream  
{
public:
	FileInputStream(const char* file); 
	virtual ~FileInputStream();

public:

	FileInputStream& operator >>( JDouble& );
	FileInputStream& operator >>( JInt& );
	FileInputStream& operator >>( char* );

	int eof();

public:
	bool EnshureOpened();

protected:
	ifstream f;
};

class FileOutputStream
{	
public:
	FileOutputStream(const char* file);
	virtual ~FileOutputStream();

public:

	FileOutputStream& operator <<( const JDouble& );
	FileOutputStream& operator <<( const JInt& );
	FileOutputStream& operator <<( const char*);

public:
	bool EnshureOpened();

public:
	ostream& raw();

public:
	void stress();

protected:
	ofstream f;	

};

#endif // !defined(AFX_FILESTREAM_H__CB141271_52FB_4D49_8029_013749B3CDC2__INCLUDED_)
