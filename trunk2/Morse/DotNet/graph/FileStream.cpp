// FileStream.cpp: implementation of the FileStream class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "FileStream.h"

  #ifdef _DEBUG
  #define new DEBUG_NEW
  #undef THIS_FILE
  static char THIS_FILE[] = __FILE__;
  #endif



//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

FileInputStream::FileInputStream(const char *file)
{
  f.open(file);
}

FileInputStream::~FileInputStream()
{
  f.close();
}

int FileInputStream::eof() {
  return f.eof();
}

////////////////////////////////////////////////////////////////////

FileOutputStream::FileOutputStream(const char* file) {
  f.open(file);
 
}

FileOutputStream::~FileOutputStream() {
  f.flush();
  f.close();
}

void FileOutputStream::stress() {
  f<<"\n";
}

ostream& FileOutputStream::raw() {
	return f;
}

/////////////////////////////////////////////////////////////////////

FileOutputStream& FileOutputStream::operator <<(const JDouble& v) {
  f<<"\t"<<scientific<<v<<"\t";
  return *this;
}

FileInputStream& FileInputStream::operator >>(JDouble& v) {
  f>>v;
  return *this;
}

FileOutputStream& FileOutputStream::operator <<(const JInt& v) {
  f<<"\t"<<v<<"\t";
  return *this;
}

FileInputStream& FileInputStream::operator >>(JInt& v) {
  f>>v;
  return *this;
}

FileInputStream& FileInputStream::operator >>(char* s) {
   char c;
   
   do {
      f.get(c);
   }while (c != '\0' && !f.eof());

   if (!f.eof()) {
      do {
         f.get(c);
         *s++ = c;
      } while (c != '\0');
   } else {
      *s=0;
   }  
   return *this;
}

FileOutputStream& FileOutputStream::operator <<(const char* s) {
   f.put('\0');
   do {
      f.put(*s++);
   }while (*s != '\0');
   f.put('\0');

   return *this;
}

bool FileOutputStream::EnshureOpened() {
	return f.is_open();
}