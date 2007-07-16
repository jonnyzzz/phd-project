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
        <table>          
          <thead>
            <tr>
              <td>System</td>
              <td>Method</td>
              <td>Nodes</td>
              <td>Steps</td>              
            </tr>
          </thead>
          <tbody>
            <xsl:apply-templates select="computation" />
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>


  <xsl:template match="computation">
      <tr>
        <td>
          <xsl:value-of select="@system"/>
        </td>
        <td>
          <xsl:value-of select="@method"/>
        </td>
        <td>
          <xsl:value-of select="step[last()]/@nodes"/>
        </td>
        <td>
          <xsl:value-of select="@totalSteps"/>
        </td>
        <xsl:apply-templates select="entropy/entropy-step"/>
        <td>
          <a>
            <xsl:attribute name="href">
              <xsl:value-of select="draw-image/@rel-image"/>
            </xsl:attribute>
            <xsl:attribute name="target">_blank</xsl:attribute>
            <xsl:text>last image</xsl:text>
          </a>
        </td>        
      </tr>      
  </xsl:template>

  <xsl:template match="entropy-step">
    <td>
      <nobr>
        <xsl:value-of select="@value"/>
      </nobr>
    </td>
  </xsl:template>  
</xsl:stylesheet>