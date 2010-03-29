<?xml version="1.0" encoding="UTF-8" ?>

<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
   xmlns="http://www.w3.org/TR/REC-html40">



  <xsl:template match="/root/computation-root">
    <html>
      <head>
         <title>default</title>
      </head>
      <body>
        <xsl:apply-templates select="computation" />
      </body>
    </html>      
  </xsl:template>

  <xsl:template match="draw-image">
    <a>
      <xsl:attribute name="href">
        <xsl:value-of select="@rel-image"/>
      </xsl:attribute>
      <xsl:attribute name="alt">image</xsl:attribute>
      <xsl:attribute name="style">border:0;</xsl:attribute>
      <img>
        <xsl:attribute name="src">
          <xsl:value-of select="@rel-image"/>
        </xsl:attribute>
        <xsl:attribute name="style">width: 250px;</xsl:attribute>
      </img>
    </a>
  </xsl:template>
  
  <xsl:template match="computation">
    <h1><xsl:value-of select="@system"/> - <xsl:value-of select="@method"/></h1>
    <table>
      <tr><td>Coordinate System</td><td><xsl:value-of select="@ics"/></td></tr>
      <tr><td>Computation time</td><td><xsl:value-of select="@time"/>ms</td></tr>
      <tr><td>Components</td><td><xsl:value-of select="step[last()]/graph/@components"/></td></tr>
      <tr><td>Number of steps</td><td><xsl:value-of select="@totalSteps"/></td></tr>
      <tr><td>Number of nodes</td><td><xsl:value-of select="step[last()]/@nodes"/></td></tr>
      <tr><td colspan="2"> <xsl:apply-templates select="draw-image"/> </td></tr>
      <xsl:apply-templates select="step"/>
      <tr><td><b>entropy-value</b></td>
          <td><b><xsl:value-of select="step[last()]/entropy/@value"/></b>(<xsl:apply-templates select="step[last()]/entropy/entropy-step"/>)</td>
      </tr>
      <tr><td>entropy-time</td><td><xsl:value-of select="step[last()]/entropy/@time"/>ms</td></tr>
    </table>      
  </xsl:template>

  <xsl:template match="entropy-step">
    <xsl:value-of select="@value"/>
    <xsl:text>, </xsl:text>
  </xsl:template>
  
  <xsl:template match="step">
    <tr>
      <td> Step <xsl:value-of select="@step"/></td>
      <td> <xsl:apply-templates select="graph/components"/> </td>
    </tr>
  </xsl:template>

  <xsl:template match="components">
    <xsl:value-of select="@count"/>
    (<xsl:apply-templates select="component"/>)
  </xsl:template>

  <xsl:template match="component">
    <xsl:value-of select="@count"/>,
  </xsl:template>
  
</xsl:stylesheet>