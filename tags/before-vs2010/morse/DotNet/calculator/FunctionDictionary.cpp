#include "StdAfx.h"
#include ".\functiondictionary.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionDictionary::FunctionDictionary(void)
{
   root = NULL;
   maxID = 0;
}

FunctionDictionary::~FunctionDictionary(void)
{
   while (root != NULL) {
      record* tmp = root;
      root = root->next;
      delete[] tmp->name;
      delete tmp;
   }     
}

int FunctionDictionary::registerVariable(const char* name) {
   record* tmp = find(name);
   if (tmp == NULL) {
      tmp = insert(name);
   }
   return tmp->id;
}

const char* FunctionDictionary::getName(int variableID) {
   record* tmp = find(variableID);
   if (tmp != 0) {
      return tmp->name;
   } else {
      sprintf(buff, "[%d]", variableID);
      return buff;
   }
}

int FunctionDictionary::lookUp(const char* name) {
   record* r = find(name);
   return (r == NULL)?-1:r->id;
}

FunctionDictionary::record* FunctionDictionary::find(int id) {
   record* tmp = root;
   while (tmp != NULL) {
      if (tmp->id == id) return tmp;
      tmp = tmp->next;
   }
   return NULL;
}

FunctionDictionary::record* FunctionDictionary::find(const char* name) {
   record* tmp = root;
   while (tmp != NULL) {
      if (stricmp(name, tmp->name) == 0) return tmp;
      tmp = tmp->next;
   }
   return NULL;
}  
   
FunctionDictionary::record* FunctionDictionary::insert(const char *name) {
   record* tmp = new record;
   tmp->name = new char[2 + strlen(name)];
   strcpy(tmp->name, name);
   tmp->id = ++maxID;
   tmp->next = root;
   root = tmp;
   return root;
}

   