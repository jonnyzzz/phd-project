#-----Macros---------------------------------

CXX = gcc 

CXXFLAGS = -x c++ -I .

OUT = gccbuild


#-----Suffix Rules---------------------------
# set up C++ suffixes and relationship between .cc and .o files

.SUFFIXES: .cpp

.cpp :  ->   $(CXX) $(CXXFLAGS) $< -o3 $@ -lm $(TLIB) -lg++

#-----File Dependencies----------------------



#-----File Dependencies----------------------

SRC = stdafx.cpp         \
      ConsoleTool.cpp \
      TorstenFunction.cpp \
      Util.cpp


OBJ = $(addsuffix .o, $(basename $(SRC)))

usepix: $(OBJ) -> $(CXX) $(CXXFLAGS) -o $@ $(OBJ) -lm $(TLIB) -lg++
  
  
#-----Other stuff----------------------------
depend: makedepend $(CXXFLAGS) -Y $(SRC)

clean: $(OBJ) ->  rm -f $(OBJ)
