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
          <td>MinusTwo</td>
          <td>MinusOne</td>
          <td>Const</td>
          <td>Linear</td>
          <td>Square</td>
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
      <td><xsl:value-of select="entropy[@entropy-type='MinusTwo']/entropy-step[@project='0']/@value"/></td>
      <td><xsl:value-of select="entropy[@entropy-type='MinusOne']/entropy-step[@project='0']/@value"/></td>
      <td><xsl:value-of select="entropy[@entropy-type='Const']/entropy-step[@project='0']/@value"/></td>      
      <td><xsl:value-of select="entropy[@entropy-type='Linear']/entropy-step[@project='0']/@value"/></td>
      <td><xsl:value-of select="entropy[@entropy-type='Square']/entropy-step[@project='0']/@value"/></td>
    </tr>
  </xsl:template>  
</xsl:stylesheet>