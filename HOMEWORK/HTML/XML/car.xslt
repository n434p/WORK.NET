<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>

    <xsl:template match="/">
      <html>
        <body>
          <h1>My Cars</h1>
          <hr/>
          <table width="100%" border="1">
            <tr bgcolor="gold">
              <th>Manufactured</th>
              <th>Model</th>
              <th>Year</th>
              <th>Speed</th>
              <th>Color</th>
            </tr>
            <xsl:for-each select="cars/car">
              <tr>
                <td>
                  <xsl:value-of select="manufactured"/>
                </td>
                <td>
                  <xsl:value-of select="model"/>
                </td>
                <td>
                  <xsl:value-of select="year"/>
                </td>
                <td>
                  <xsl:value-of select="speed"/>
                </td>
                <td>
                  <xsl:value-of select="color"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
