<?xml version="1.0" encoding="UTF-8" ?>

<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
   xmlns="http://www.w3.org/TR/REC-html40">

  <xsl:template match="/root/computation-root">
    <html>
      <head>
        <title>last-entropy</title>
        <style>
          <xsl:attribute name="type">text/css</xsl:attribute>
          <xsl:text>
          h1, h2 { padding : 0; margin : 0; }
          
          table {          
              border-collapse: separate; 
              border-spacing: 2px 1px;
              margin: 0 auto;
              padding-top : 5px;
              padding-left: 40px;
              text-align:center;
              width:auto;              
          }
          
          table thead {
              background-color: #FAB73C;
              border: 1px solid #B38D2E;
          }

          table td {
              text-align:left;
              padding: 2px 2px 2px 2px;
              margin: 2px 2px 2px 2px;
              white-space: nowrap;
          }
          </xsl:text>
        </style>
      </head>
      <body>
        <xsl:apply-templates select="computation" />
      </body>
    </html>
  </xsl:template>


  <xsl:template match="computation">
    <h1>
      <xsl:value-of select="@system"/>
      <xsl:text> </xsl:text>
      <xsl:value-of select="@method"/>
    </h1>
        
    <table>
      <thead>
        <tr>
          <td>Step</td>
          <xsl:for-each select="step[last()]/entropy">
            <xsl:sort select="@entropy-type"/>
            <td><xsl:value-of select="@entropy-type"/></td>
          </xsl:for-each>
        </tr>
      </thead>
      <tbody>
        <tr>
          <xsl:apply-templates select="step"/>
        </tr>
      </tbody>
    </table>

    <xsl:apply-templates select="draw-image[@type='entropy']"/>
  </xsl:template>
  
  <xsl:template match="step">
    <tr>
      <td><xsl:apply-templates select="@step"/></td>
      <xsl:for-each select="entropy">
        <xsl:sort select="@entropy-type"/>
        <td>
          <xsl:value-of select="entropy-step[@project='0']/@value"/>
          <small>
            <xsl:text>(</xsl:text>
            <xsl:number value="ceiling((@usedEdges div @graphEdges) * 10000) div 100.0"/>
            <xsl:text>%)</xsl:text>
          </small>
        </td>
      </xsl:for-each>
    </tr>
  </xsl:template>      
</xsl:stylesheet>