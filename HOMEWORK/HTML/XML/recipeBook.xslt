<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <!--<xsl:output method="xml" indent="yes"/>-->

  
    <xsl:template match="/">
      
      <html>
        <body>
          <h1>Recipes Book</h1>
          <hr/>
          
            <xsl:for-each select="recipeBook/recipe">
              <img src="{@image}" width="200px" height="200px" style="display:block;margin:auto;"/>
              <p style="text-align:center;">
                <xsl:value-of select="@name"/>
                <br/>
                INFO: <xsl:value-of select="./info"/>
              </p>

              <table width="100%" border="1">
                <tr bgcolor="lightgreen">
                  <th>INGREDIENT</th>
                  <th>MEASURE</th>
                  <th>Q-TY</th>
                  <th>COOKING</th>
                  <th>TIME</th>
                </tr>
              
              <xsl:for-each select="ingredient">
              <tr>
                <td>
                  <xsl:value-of select="."/>
                </td>
                <td>
                  <xsl:value-of select="@measure"/>
                </td>
                <td>
                  <xsl:value-of select="@quantity"/>
                </td>
                <td>
                  <xsl:value-of select="@cookMode"/>
                </td>
                <td>
                  <xsl:value-of select="@time"/>
                </td>
              </tr>
              </xsl:for-each>
            
          </table>
            </xsl:for-each>
          
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
