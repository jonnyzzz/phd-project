<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
   xmlns="http://www.w3.org/TR/REC-html40">



<xsl:template match="/log">
  <xsl:apply-templates mode="CompareResults" select="."/>
</xsl:template>


<xsl:template mode="CompareResults" match="/log">
  <table border="1">
    <tr>
       <td>Method</td>
       <td>Nodes</td>
       <td>Edges</td>
       <td>Computation Time</td>
       <td>Components</td>
       <td>Steps</td>
     </tr>
    <xsl:apply-templates mode="CompareResultsSub" select="/log/log"/>
  </table>
</xsl:template>

<xsl:template mode="CompareResultsSub" match="/log/log">
   <tr>
     <td><xsl:value-of select="@method"/></td>
     <td>
         <xsl:attribute name="align">right</xsl:attribute>
         <xsl:number value="sum(Result[position() = last()]/graphResult/@Nodes)" grouping-size="3" grouping-separator=" "/>
     </td>
     <td>
         <xsl:attribute name="align">right</xsl:attribute>
         <xsl:number value="sum(Result[position() = last()]/graphResult/@Edges)" grouping-size="3" grouping-separator=" "/>
     </td>
     <td>
         <xsl:attribute name="align">right</xsl:attribute>
         <xsl:number value="(IterationFinished[position() = last()]/@timeMiniseconds)" grouping-size="3" grouping-separator=" "/><xsl:text> ms</xsl:text>
     </td>
     <td>
         <xsl:attribute name="align">right</xsl:attribute>
         <xsl:value-of select="count(Result[position() = last()]/graphResult)"/>
     </td>
     <td>
         <xsl:attribute name="align">right</xsl:attribute>
         <xsl:value-of select="number(IterationFinished[position() = last()]/@step) + 1"/>
     </td>
   </tr>
</xsl:template>


</xsl:stylesheet>