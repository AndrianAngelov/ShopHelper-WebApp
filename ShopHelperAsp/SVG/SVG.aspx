﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SVG.aspx.cs" Inherits="ShopHelperAsp.SVG.SVG" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="SVG_CSS/ShopHelper_Architecture.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%--<?xml-stylesheet type="text/css" href="SVG_CSS/ShopHelper_Architecture.css" ?>--%>
      <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
         version="1.1" id="Layer_1" width="350px" height="240px" >

      <defs>
        <style type="text/css">
          <![CDATA[
    
  .webPC-path
{
	fill:url(#WebPC-pattern) ;
}

.desktopPC-path
{
	fill:url(#DesktopPC-pattern) ;
}
.AspServer-path
{
	fill:url(#AspServer-pattern) ;
}
.WCFServer-path
{
	fill:url(#WCFServer-pattern) ;
}
.SQLServer-path
{
	fill:url(#SQLServer-pattern) ;
}
.logo-face
{
	fill:#FFF8DC;
}
.logo-eyes
{
	fill:#282828;
}
    ]]>
        </style>
      </defs>

      <!-- start TEXT-->
      <g  id="TEXT" class="all">
        <!--WebClient-text-->
        <text id="WebClient-text" class="text all" x = "5" y = "42">
          Web client
          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "0"
                to            = "42px"
                begin         = "2.5s"
                dur           = "1s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "2.5s"
                id            = "WebClient-text"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "2.5s"
                dur           = "1s"
                id            = "WebClient-text"
	    />
        </text>

        <!--ASP-text-->
        <text id="ASP-text" class="text all" x = "103" y = "42"  >
          Asp.Net

          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "0px"
                to            = "42px"
                begin         = "5s"
                dur           = "1s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "5s"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "5s"
                dur           = "1s"
	    />
        </text>

        <!--WindowsForms-text-->
        <text id="WindowsForms-text" class="text all" x = "80" y = "192"  >
          Windows Forms
          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "234px"
                to            = "192px"
                begin         = "2.5s"
                dur           = "1s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "2.5s"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "2.5s"
                dur           = "1s"
	    />
        </text>

        <!--WCF-text-->
        <text id="WCF-text" class="text all" x = "198" y = "77"  >
          WCF
          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "0px"
                to            = "77px"
                begin         = "7.5s"
                dur           = "1s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "7.5s"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "7.5s"
                dur           = "1s"
	    />
        </text>

        <!--BLL-DAL-text-->
        <text id="BAL-DAL" class="text all" x = "192" y = "156"  >
          BLL&amp;DAL
          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "234px"
                to            = "156px"
                begin         = "8.5s"
                dur           = "0.5s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "8.5s"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "8.5s"
                dur           = "0.5s"
	    />
        </text>

        <!--SQL-text-->
        <text id="SQL-text" class="text all" x = "260" y = "85"  >
          SQL Server
          <!--from where to show-->
          <animate
                attributeName = "y"
                from          = "0px"
                to            = "85px"
                begin         = "10.5s"
                dur           = "1s"
    	/>

          <!--how long is not visible-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "0"
                begin         = "0s"
                dur           = "10.5s"
	    />

          <!--how long to continue slow filling-->
          <animate
                attributeName = "opacity"
                from          = "0"
                to            = "1"
                begin         = "10.5s"
                dur           = "1s"
	    />
        </text>
      </g>
      <!-- end TEXT-->

      <!--=================================== start Logo a.k.a Ugly Face =======================================-->
      <%--<g id="Logo" class="all" transform="matrix(0.000401676, 0.390804, 0.325806, -0.000233911, 44.45, 165.5)">
        <path class="logo-face logo" d="M49.9 -0.5L49.9 41.95L-18.75 41.95Q-31.4 42 -40.9 29.75Q-49.9 17.1 -49.9 -0.5L-49.9 -42L18.75 -42Q31.8 -42 40.9 -29.85Q49.9 -17.6 49.9 -0.5" />
      </g>

      <g id="Logo-LeftEye" class="all" transform="matrix(0.122815, -0.343666, 0.435153, 0.108615, 42.05, 166.7)" >
        <path class="left-eye-path logo-eyes logo" d="M15.4 -27.95Q19.4 -27.9 23 -25.7Q26.35 -23.6 28.1 -20.1Q29.65 -17 29.6 -13.5Q29.65 -11.1 28.7 -8.65Q27.8 -6.2 26.2 -4.35Q24.05 -1.8 20.9 -0.5Q18.25 0.6 15.4 0.55Q10.7 0.6 7 -2.2Q4 -4.3 2.5 -7.75Q1.2 -10.6 1.2 -13.75Q1.2 -19.9 5.7 -24.05Q9.9 -27.9 15.4 -27.95M14.7 -26.35L14.6 -1.15L15.65 -1.1Q19.15 -1.1 22.3 -3.05Q25.35 -5 26.9 -8.1Q28.1 -10.6 28.1 -13.6Q28.1 -19.6 23.6 -23.35Q20.05 -26.4 15.8 -26.4L14.7 -26.4" />
      </g>

      <g id="Logo-RightEye" class="all" transform="matrix(-0.085625, -0.351455, 0.445016, -0.0757246, 58.7, 164)" >
        <path class="right-eye-path logo-eyes logo" d="M15.4 -27.95Q19.4 -27.9 23 -25.7Q26.35 -23.6 28.1 -20.1Q29.65 -17 29.6 -13.5Q29.65 -11.1 28.7 -8.65Q27.8 -6.2 26.2 -4.35Q24.05 -1.8 20.9 -0.5Q18.25 0.6 15.4 0.55Q10.7 0.6 7 -2.2Q4 -4.3 2.5 -7.75Q1.2 -10.6 1.2 -13.75Q1.2 -19.9 5.7 -24.05Q9.9 -27.9 15.4 -27.95M14.7 -26.35L14.6 -1.15L15.65 -1.1Q19.15 -1.1 22.3 -3.05Q25.35 -5 26.9 -8.1Q28.1 -10.6 28.1 -13.6Q28.1 -19.6 23.6 -23.35Q20.05 -26.4 15.8 -26.4L14.7 -26.4"/>
      </g>

      <g id="Logo-Nose" class="all" transform="matrix(0.407063, -0.0171171, 0.0141068, 0.429531, 44.05, 175.8)" >
        <path class="logo-nose-path logo" d="M3.1 0Q4.25 -20.9 4.5 -34.45L5.95 -34.4L7.5 -34.45L6.85 -21.9L6.05 0L4.55 0L3.1 0" />
      </g>

      <g id="Logo-mouth" class="all" transform="matrix(-0.108262, 0.053066, 0.0634967, 0.0904775, 46.5, 176.85)">
        <path class="logo-mouth-path logo" d="M-78.45 44.9L78.5 -44.9L45.05 44.9L-78.45 44.9" />
      </g>--%>

      <g id="PathMustaka" transform="matrix(1, 0, 0, 1, 55, 160)" opacity="1">
        <pattern 
        id="PatternMustaka" patternUnits="userSpaceOnUse" overflow="visible" width="85" height="60" viewBox="0 0 85 60" patternTransform="matrix(1, 0, 0, 1, -42.5, -80)"
        >
        <image 
        width="50" height="40"
        xlink:href="data:image/png;base64,
        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"
        >
        </image>
        </pattern>
        <path style="fill:url(#PatternMustaka) " d="M-42.5 30L42.5 30L42.5 -30L-42.5 -30L-42.5 30" />
        <!--from where to show-->
		        <animateMotion
	    	        from="0,50"
		 	        to="0,0"
		 	        begin="0s"
	    	        dur="1s" 
			        fill="freeze"/>
        </g>
      <!--=================================== end Logo=======================================-->

      <!--=================================== start Images =======================================-->
      <!--WebPC image-->
      <g id="WebPC" class="all" transform="matrix(0.571267, 0, 0, 0.704918, 43.3, 70.25)" >
        <pattern id="WebPC-pattern" patternUnits="userSpaceOnUse" overflow="visible" width="64" height="64" viewBox="0 0 65 65" patternTransform="matrix(1, 0, 0, 1, -32, -32)">
          <image width="64" height="64" xlink:href="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAiEgAAIhIBv2R/3AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAICSURBVHic7Zsxi9NgHIeff5oM4rUuN5UDN0FEOuQdSj3nw0G4wVW/gIO7630F/R6Hmzh0OMFAi5OT8+HiItIpqfwd5PDuiD3qpflV8z5TeUnePnlo0heSmLvTZRK1gJoYQC2gJgZQC6iJAdQCajofID37MB6P95bL5Y5Spi3SNF0URXEKYHme3wdeAw+1Wq1zAjzvDYfDV8AjtY2A28BuAhyqTYQcJkCmthCSpTWDP4B52yYtEYDe+YG6AIv5fD5ux6ddQgjfgFvnxzq/DogB1AJqYgC1gJoYQC2gJgZQC6iJAdQCamIAtYCaGEAtoCYGUAuoiQHUAmpiALWAmhhALaAmBlALqIkB1AJqYgC1gJrOB6i7Pd7L8/y/vD1uZr3LY3UBdszsQws+W0HnT4EYQC2gJgEqtYSQKgGO1RZCjhPgiF+PjXaNE+DIzt4a6+zD0l1/ba5uIdQYIYTM3Q+A3b/Z38y+9vv9t9PpdNmw2u/v2NQvYDKZ3CjL8h3w4JpTfTGzg9ls9qkJr8tsbB1QluVLrn/wAEN3f9HAPLVsciH0pMG59huc6wKbDGBbOtfFia+6BphZEkJ47O5315x7390b+Vs1swXwfp193P3zYDB4c9UFdGWA0Wh0M8uyj8Cddb58izhN0/ReURTf/7TBylMgy7Jn/LsHD7BXVdXTVRv8BP9KarigePv3AAAAAElFTkSuQmCC">
          </image>
        </pattern>

        <path d="M-32 32L32 32L32 -32L-32 -32L-32 32" class="webPC-path"/>

        <!--from where to show-->
        <animateMotion
            from="-50,0"
          to="0,0"
          begin="2s"
            dur="0.5s"
          fill="freeze"/>

        <!--how long is not visible-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "0"
              begin         = "0s"
              dur           = "2s"
              id            = "DesktopPC"
	    />

        <!--how long to continue slow filling-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "1"
              begin         = "2s"
              dur           = "0.5s"
              id            = "DesktopPC"
	    />
      </g>

      <!--DesktopPC image-->
      <g id="DesktopPC" class="all" transform="matrix(0.571267, 0, 0, 0.704918, 132.3, 157.25)" >
        <pattern id="DesktopPC-pattern" patternUnits="userSpaceOnUse" overflow="visible" width="64" height="64" viewBox="0 0 65 65" patternTransform="matrix(1, 0, 0, 1, -32, -32)">
          <image width="64" height="64" xlink:href="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAiEgAAIhIBv2R/3AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAICSURBVHic7Zsxi9NgHIeff5oM4rUuN5UDN0FEOuQdSj3nw0G4wVW/gIO7630F/R6Hmzh0OMFAi5OT8+HiItIpqfwd5PDuiD3qpflV8z5TeUnePnlo0heSmLvTZRK1gJoYQC2gJgZQC6iJAdQCajofID37MB6P95bL5Y5Spi3SNF0URXEKYHme3wdeAw+1Wq1zAjzvDYfDV8AjtY2A28BuAhyqTYQcJkCmthCSpTWDP4B52yYtEYDe+YG6AIv5fD5ux6ddQgjfgFvnxzq/DogB1AJqYgC1gJoYQC2gJgZQC6iJAdQCamIAtYCaGEAtoCYGUAuoiQHUAmpiALWAmhhALaAmBlALqIkB1AJqYgC1gJrOB6i7Pd7L8/y/vD1uZr3LY3UBdszsQws+W0HnT4EYQC2gJgEqtYSQKgGO1RZCjhPgiF+PjXaNE+DIzt4a6+zD0l1/ba5uIdQYIYTM3Q+A3b/Z38y+9vv9t9PpdNmw2u/v2NQvYDKZ3CjL8h3w4JpTfTGzg9ls9qkJr8tsbB1QluVLrn/wAEN3f9HAPLVsciH0pMG59huc6wKbDGBbOtfFia+6BphZEkJ47O5315x7390b+Vs1swXwfp193P3zYDB4c9UFdGWA0Wh0M8uyj8Cddb58izhN0/ReURTf/7TBylMgy7Jn/LsHD7BXVdXTVRv8BP9KarigePv3AAAAAElFTkSuQmCC">
          </image>
        </pattern>
        <path d="M-32 32L32 32L32 -32L-32 -32L-32 32" class="desktopPC-path"/>

        <!--from where to show-->
        <animateMotion
            from="0,50"
          to="0,0"
          begin="2s"
            dur="0.5s"
          fill="freeze"/>

        <!--how long is not visible-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "0"
              begin         = "0s"
              dur           = "2s"
              id            = "DesktopPC"
	    />

        <!--how long to continue slow filling-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "1"
              begin         = "2s"
              dur           = "0.5s"
              id            = "DesktopPC"
	    />
      </g>

      <!--AspServer image-->
      <g id="AspServer" class="all" transform="matrix(0.428547, 0, 0, 0.428547, 129.9, 79.7)" >
        <pattern id="AspServer-pattern" patternUnits="userSpaceOnUse" overflow="visible" width="70" height="148" viewBox="0 0 70 148" patternTransform="matrix(1, 0, 0, 1, -35, -74)">
          <image width="70" height="148" xlink:href="data:image/png;base64, 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">
          </image>
        </pattern>

        <path d="M-35 74L35 74L35 -74L-35 -74L-35 74" class="AspServer-path"/>

        <!--from where to show-->
        <animateMotion
            from="0,-80"
          to="0,0"
          begin="4.5s"
            dur="0.5s"
          fill="freeze"/>
        <!--how long is not visible-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "0"
              begin         = "0s"
              dur           = "4.5s"
	    />
        <!--how long to continue slow filling-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "1"
              begin         = "4.5s"
              dur           = "0.5s"
	    />
      </g>

      <!--WCFServer image-->
      <g id="WCFServer" class="all" transform="matrix(0.428547, 0, 0, 0.428547, 213.6, 112.7)">
        <pattern id="WCFServer-pattern" patternUnits="userSpaceOnUse" overflow="visible" width="70" height="148" viewBox="0 0 70 148" patternTransform="matrix(1, 0, 0, 1, -35, -74)">
          <image width="70" height="148" xlink:href="data:image/png;base64, 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">
          </image>
        </pattern>

        <path d="M-35 74L35 74L35 -74L-35 -74L-35 74" class="WCFServer-path"/>

        <!--from where to show-->
        <animateMotion
            from="0,-80"
          to="0,0"
          begin="7s"
            dur="0.5s"
          fill="freeze"/>
        <!--how long is not visible-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "0"
              begin         = "0s"
              dur           = "7s"
	    />
        <!--how long to continue slow filling-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "1"
              begin         = "7s"
              dur           = "0.5s"
	    />
      </g>

      <!--SQLServer image-->
      <g id="SQLServer" class="all" transform="matrix(0.08621, 0, 0, 0.108168, 301.5, 118)" >
        <pattern id="SQLServer-pattern" patternUnits="userSpaceOnUse" overflow="visible" width="512" height="512" viewBox="0 0 512 512" patternTransform="matrix(1, 0, 0, 1, -256, -256)">
          <image width="512" height="512" xlink:href="data:image/png;base64, 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">
          </image>
        </pattern>

        <path d="M-256 256L256 256L256 -256L-256 -256L-256 256" class="SQLServer-path"/>

        <!--from where to show-->
        <animateMotion
            from="0,-80"
          to="0,0"
          begin="10s"
            dur="0.5s"
          fill="freeze"/>
        <!--how long is not visible-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "0"
              begin         = "0s"
              dur           = "10s"
	    />
        <!--how long to continue slow filling-->
        <animate
              attributeName = "opacity"
              from          = "0"
              to            = "1"
              begin         = "10s"
              dur           = "0.5s"
	    />
      </g>
      <!--=================================== end Images =======================================-->

      <!--=================================== start DOTS =======================================-->
      <!--DOTS: ShopHelper to DesktopPC-->
      <g id="SH-DesktopPC" class="all" transform="matrix(-0.402743, 0.00240003, 0.00240007, 0.402743, 88.5, 158.95)" >
        <path class="dots sh-desktopPC-dots" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3" />
        <!--from where to show-->
        <animateMotion
          from="-50,0"
        to="0,0"
        begin="3.5s"
          dur="1s"
        fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "3.5s"
	    	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "3.5s"
            dur           = "1s"
	    	/>
      </g>

      <!--DOTS: ShopHelper to WebPC-->
      <g id="SH-WebPC" class="all" transform="matrix(-0.00261831, 0.402742, 0.402742, 0.00261828, 41.2, 119.2)" >
        <path  class="dots sh-WebClient" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3" />
        <!--from where to show-->
        <animateMotion
          from="0,50"
        to="0,0"
        begin="3.5s"
          dur="1s"
        fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "3.5s"
	    	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "3.5s"
            dur           = "1s"
	    	/>
      </g>

      <!--DOTS: WebClient to AspServer-->
      <g id="WebPC-ASP" class="all" transform="matrix(-0.402638, -0.00952679, -0.00952674, 0.402638, 88.5, 72.6)" >
        <path class="dots" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3" />
        <!--from where to show-->
        <animateMotion
          from="-50,0"
        to="0,0"
        begin="6s"
          dur="1s"
        fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "6s"
	    	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "6s"
            dur           = "1s"
	    	/>
      </g>

      <!--DOTS: AspServer to WCFServer-->
      <g id="ASP-WCF" class="all" transform="matrix(-0.353118, -0.193689, -0.193689, 0.353118, 172.5, 86.75)" >
        <path  class="dots" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3"/>

        <!--from where to show-->
        <animateMotion
          from="-50,-25"
        to="0,0"
        begin="9s"
          dur="1s"
        fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "9s"
	    	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "9s"
            dur           = "1s"
	    	/>
      </g>

      <!--DOTS: DsktopPC to WCFServer-->
      <g id="DesktopPC-WCF" class="all" transform="matrix(0.289491, -0.280006, -0.280006, -0.289491, 175.5, 144.05)" >
        <path class="dots" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3"/>
        <!--from where to show-->
        <animateMotion
          from="-50,50"
        to="0,0"
        begin="9s"
          dur="1s"
        fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "9s"
	    	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "9s"
            dur           = "1s"
	    	/>
      </g>

      <!--DOTS: WCFServer to SQLServer-->
      <g id="WCF-SQL" class="all" transform="matrix(-0.402638, -0.00952679, -0.00952674, 0.402638, 255.5, 112.6)" >
        <path class="dots" d="M26.1 -2.1Q27 -1.2 27 0Q27 1.2 26.1 2.1Q25.2 3 24 3Q22.8 3 21.9 2.1Q21 1.2 21 0Q21 -1.2 21.9 -2.1Q22.8 -3 24 -3Q25.2 -3 26.1 -2.1M36 -3Q37.2 -3 38.1 -2.1Q39 -1.2 39 0Q39 1.2 38.1 2.1Q37.2 3 36 3Q34.8 3 33.9 2.1Q33 1.2 33 0Q33 -1.2 33.9 -2.1Q34.8 -3 36 -3M12 -3Q13.2 -3 14.1 -2.1Q15 -1.2 15 0Q15 1.2 14.1 2.1Q13.2 3 12 3Q10.8 3 9.9 2.1Q9 1.2 9 0Q9 -1.2 9.9 -2.1Q10.8 -3 12 -3M2.1 -2.1Q3 -1.2 3 0Q3 1.2 2.1 2.1Q1.2 3 0 3Q-1.2 3 -2.1 2.1Q-3 1.2 -3 0Q-3 -1.2 -2.1 -2.1Q-1.2 -3 0 -3Q1.2 -3 2.1 -2.1M48 -3Q49.2 -3 50.1 -2.1Q51 -1.2 51 0Q51 1.2 50.1 2.1Q49.2 3 48 3Q46.8 3 45.9 2.1Q45 1.2 45 0Q45 -1.2 45.9 -2.1Q46.8 -3 48 -3M-48 -3Q-46.8 -3 -45.9 -2.1Q-45 -1.2 -45 0Q-45 1.2 -45.9 2.1Q-46.8 3 -48 3Q-49.2 3 -50.1 2.1Q-51 1.2 -51 0Q-51 -1.2 -50.1 -2.1Q-49.2 -3 -48 -3M-9.9 -2.1Q-9 -1.2 -9 0Q-9 1.2 -9.9 2.1Q-10.8 3 -12 3Q-13.2 3 -14.1 2.1Q-15 1.2 -15 0Q-15 -1.2 -14.1 -2.1Q-13.2 -3 -12 -3Q-10.8 -3 -9.9 -2.1M-36 -3Q-34.8 -3 -33.9 -2.1Q-33 -1.2 -33 0Q-33 1.2 -33.9 2.1Q-34.8 3 -36 3Q-37.2 3 -38.1 2.1Q-39 1.2 -39 0Q-39 -1.2 -38.1 -2.1Q-37.2 -3 -36 -3M-24 -3Q-22.8 -3 -21.9 -2.1Q-21 -1.2 -21 0Q-21 1.2 -21.9 2.1Q-22.8 3 -24 3Q-25.2 3 -26.1 2.1Q-27 1.2 -27 0Q-27 -1.2 -26.1 -2.1Q-25.2 -3 -24 -3" />

        <!--from where to show-->
        <animateMotion
          from="-20,0"
          to="0,0"
          begin="11.5s"
          dur="0.5s"
          fill="freeze"/>

        <!--how long is not visible-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "0"
            begin         = "0s"
            dur           = "11.5s"
	/>

        <!--how long to continue slow filling-->
        <animate
            attributeName = "opacity"
            from          = "0"
            to            = "1"
            begin         = "11.5s"
            dur           = "0.5s"
	/>
      </g>
      <!--=================================== end DOTS =======================================-->

    </svg>
</body>
</html>
