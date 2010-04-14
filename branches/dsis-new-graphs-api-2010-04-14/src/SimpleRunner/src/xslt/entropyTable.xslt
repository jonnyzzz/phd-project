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
    <h2>
      <xsl:text>nodes=</xsl:text>
      <xsl:value-of select="step[last()]/@nodes"/>
      <xsl:text> steps</xsl:text>
      <xsl:value-of select="@totalSteps"/>
      <xsl:text> </xsl:text>
      <a>
        <xsl:attribute name="href">
          <xsl:value-of select="draw-image/@rel-image"/>
        </xsl:attribute>
        <xsl:attribute name="target">_blank</xsl:attribute>
        <xsl:text>image</xsl:text>
      </a>
    </h2>

    <table>
      <thead>
        <tr>
          <xsl:apply-templates select="step" mode="head"/>
        </tr>
      </thead>
      <tbody>
        <tr>
          <xsl:apply-templates select="step" mode="body"/>
        </tr>
      </tbody>
    </table>

    <xsl:apply-templates select="draw-image[@type='entropy']"/>
  </xsl:template>

  <xsl:template match="step" mode="head">
    <td>
      <xsl:text>step </xsl:text>
      <xsl:value-of select="@step"/>
    </td>
  </xsl:template>

  <xsl:template match="step" mode="body">
    <td>
      <xsl:apply-templates select="entropy/entropy-step"/>
    </td>
  </xsl:template>

  <xsl:template match="entropy-step">    
    <xsl:value-of select="@value"/>
    <br />
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
</xsl:stylesheet>