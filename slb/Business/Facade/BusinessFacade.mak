#
# Makefile for the Duwamish 7.0 Sample Application, BusinessFacade Assembly
#

#
# Include Shared definitions
#
!include ..\..\shared.mak

#
# The target Assembly
#
TARGET=..\..\$(WEBDIR)\bin\Duwamish7.BusinessFacade.dll

#
# Referenced Assemblies
#
REFERENCES= \
	-r:System.dll \
	-r:System.Data.dll \
	-r:System.Xml.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.SystemFramework.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.Common.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.DataAccess.dll \
	-r:..\..\$(WEBDIR)\bin\Duwamish7.BusinessRules.dll

#
# The Sources
#
SOURCES= \
	AssemblyInfo.vb \
	CustomerSystem.vb \
	OrderSystem.vb \
	ProductSystem.vb

#
# Everything
#
all	: $(TARGET)
	

$(TARGET) : $(SOURCES)
	vbc.exe $(VBCOPTS) -target:library $(REFERENCES) $(SOURCES) -out:$(TARGET)
