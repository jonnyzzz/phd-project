CXX = gcc
CXXFLAGS = -x c++ -I.
CXXLINK = -o programm

SRC_CELLIMAGEBUILDER = AbstractBoxProcess.cpp \
                AbstractGraphCreator.cpp \
                AbstractPointBuilder.cpp \
                AbstractProcess.cpp     \
                AbstractProcessExt.cpp   \
                BuildersException.cpp     \
                GraphSet.cpp               \
                MS2DBoxProcess.cpp          \
                LoopsLocalizationProcess.cpp \
                MS2DCreationProcess.cpp       \
                MSCreationProcess.cpp          \
                MSOverlapedPointBuilder.cpp     \
                MSPointBuilder.cpp               \
                Processes.cpp                     \
                ProgressBarInfo.cpp                \
                ProjectionProcess.cpp               \
                SIOverlapedPointBuilder.cpp          \
                SIPointBuilder.cpp                    \
                SegmentProjectiveBundleMSCreationProcess.cpp\
                SimpleBoxProcess.cpp                         \
                TarjanProcess.cpp                             
DIR_CELLIMAGEBUILDER = cellImageBuilders/

SRC_GRAPH = CoordinateSystem.cpp           \
            ExtendedMenoryManager.cpp       \
            FileStream.cpp  \
            Graph.cpp         \
            GraphComponents.cpp \
            GraphException.cpp                    \
            GraphUtil.cpp                          \
            MemoryManager.cpp                         \
            Stack.cpp                                   
DIR_GRAPH = graph/

SRC_GRAPH_SIMPLEX = Rom.cpp \
                    RomFunction2N.cpp \
                    SIRom.cpp 
DIR_GRAPH_SIMPLEX = graph_simplex/

SRC_SYSTEM_FUNCTION =  IMorseFunction.cpp \
                       IProjectiveExtensionInfo.cpp \
                       ISystemFunction.cpp \
                       ISystemFunctionDerivate.cpp \
                       MS2DAngleFunction.cpp \
                       MS2DAngleMorseFunction.cpp \
                       SermentProjectiveExtensionInfo.cpp \
                       SegmentProjectiveExtendedSystemFunction.cpp \
                       SegmentProjectiveExtensionMorseFunction.cpp 
DIR_SYSTEM_FUNCTION = SystemFunction/

SRC_CONSOLE_TOOL = ConsoleTool.cpp \
                   TorstenFunction.cpp \
                   Util.cpp
DIR_CONSOLE_TOOL = ConsoleTool/

SRC = $(addprefix $(DIR_CELLIMAGEBUILDER), $(SRC_CELLIMAGEBUILDER)) \
      $(addprefix $(DIR_GRAPH), $(SRC_GRAPH)) \
      $(addprefix $(DIR_GRAPH_SIMPLEX), $(SRC_GRAPH_SIMPLEX)) \
      $(addprefix $(DIR_SYSTEM_FUNCTION), $(SRC_SYSTEM_FUNCTION)) \
      $(addprefix $(DIR_CONSOLE_TOOL), $(SRC_CONSOLE_TOOL))

OBJ = $(addsuffix .o, $(basename $(SRC)))

all:;  $(CXX) $(CXXFLAGS) -o runny $(SRC)

link:;  $(CXX) $(CXXLINK) -o runny $(OBJ) -lm $(TLIB) -lg++ -o3

clean:; rm -f $(OBJ)