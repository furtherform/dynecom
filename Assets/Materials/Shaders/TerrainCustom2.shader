// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33494,y:32750,varname:node_9361,prsc:2|diff-9047-OUT,spec-6636-OUT,gloss-4377-OUT,normal-2367-OUT,custl-9047-OUT,olwid-1858-OUT,olcol-137-RGB;n:type:ShaderForge.SFN_LightVector,id:6869,x:32042,y:32834,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:32042,y:32962,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:7782,x:32213,y:32881,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7528,x:33010,y:33664,varname:node_7528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2460,x:33176,y:33491,cmnt:Ambient Light,varname:node_2460,prsc:2|A-544-OUT,B-8332-OUT;n:type:ShaderForge.SFN_Multiply,id:544,x:32231,y:32515,cmnt:Diffuse Color,varname:node_544,prsc:2|A-6274-OUT,B-4464-OUT;n:type:ShaderForge.SFN_Set,id:9764,x:32472,y:32337,varname:BCol,prsc:2|IN-544-OUT;n:type:ShaderForge.SFN_Set,id:2232,x:32386,y:32881,varname:lOut,prsc:2|IN-7782-OUT;n:type:ShaderForge.SFN_Get,id:5516,x:31340,y:33318,varname:node_5516,prsc:2|IN-2232-OUT;n:type:ShaderForge.SFN_Get,id:1515,x:32366,y:33211,varname:node_1515,prsc:2|IN-9764-OUT;n:type:ShaderForge.SFN_Multiply,id:3566,x:32578,y:33363,cmnt:Modify how dark you want the shadows,varname:node_3566,prsc:2|A-1515-OUT,B-780-OUT;n:type:ShaderForge.SFN_Slider,id:6152,x:32366,y:33109,ptovrint:False,ptlb:ShadowDarkness,ptin:_ShadowDarkness,varname:node_6152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_LightColor,id:829,x:32116,y:33484,varname:node_829,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:1442,x:32116,y:33618,varname:node_1442,prsc:2;n:type:ShaderForge.SFN_Multiply,id:780,x:32366,y:33403,varname:node_780,prsc:2|A-5724-OUT,B-1442-OUT,C-829-RGB;n:type:ShaderForge.SFN_ValueProperty,id:2501,x:31459,y:32887,ptovrint:False,ptlb:Tones,ptin:_Tones,varname:node_2501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Subtract,id:1389,x:31647,y:32857,cmnt:Number of lighting tones,varname:node_1389,prsc:2|A-2501-OUT,B-3959-OUT;n:type:ShaderForge.SFN_Vector1,id:3959,x:31448,y:32979,varname:node_3959,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:7240,x:31830,y:32857,varname:Tones,prsc:2|IN-1389-OUT;n:type:ShaderForge.SFN_Multiply,id:9291,x:31648,y:33315,varname:node_9291,prsc:2|A-5516-OUT,B-3440-OUT;n:type:ShaderForge.SFN_Get,id:3440,x:31700,y:33185,varname:node_3440,prsc:2|IN-7240-OUT;n:type:ShaderForge.SFN_Round,id:2840,x:31832,y:33327,cmnt:Clamp the lighting,varname:node_2840,prsc:2|IN-9291-OUT;n:type:ShaderForge.SFN_Divide,id:5724,x:32019,y:33327,varname:node_5724,prsc:2|A-2840-OUT,B-3440-OUT;n:type:ShaderForge.SFN_Lerp,id:2189,x:32826,y:32992,varname:node_2189,prsc:2|A-1515-OUT,B-311-OUT,T-6152-OUT;n:type:ShaderForge.SFN_Lerp,id:6441,x:32972,y:32122,varname:node_6441,prsc:2|A-3379-OUT,B-9440-OUT,T-388-OUT;n:type:ShaderForge.SFN_Lerp,id:2367,x:32169,y:31539,varname:node_2367,prsc:2|A-1825-OUT,B-4260-OUT,T-7809-OUT;n:type:ShaderForge.SFN_Slider,id:7809,x:31856,y:31399,ptovrint:False,ptlb:normal strenght,ptin:_normalstrenght,varname:node_7809,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Vector3,id:4260,x:31895,y:31576,varname:node_4260,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Fresnel,id:9954,x:32540,y:31990,varname:node_9954,prsc:2|EXP-7014-OUT;n:type:ShaderForge.SFN_Vector1,id:9440,x:32687,y:32180,varname:node_9440,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:3379,x:32729,y:32055,varname:node_3379,prsc:2|A-9954-OUT,B-6253-RGB;n:type:ShaderForge.SFN_Cubemap,id:6253,x:32453,y:32149,ptovrint:False,ptlb:rim light map,ptin:_rimlightmap,varname:node_6253,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0;n:type:ShaderForge.SFN_Slider,id:7014,x:32171,y:32024,ptovrint:False,ptlb:freshnel strenght,ptin:_freshnelstrenght,varname:node_7014,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6.860362,max:10;n:type:ShaderForge.SFN_Slider,id:388,x:32642,y:32323,ptovrint:False,ptlb:reflection strength,ptin:_reflectionstrength,varname:node_388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1861916,max:1;n:type:ShaderForge.SFN_Lerp,id:6274,x:32058,y:32274,varname:node_6274,prsc:2|A-4464-OUT,B-5735-OUT,T-5452-OUT;n:type:ShaderForge.SFN_Lerp,id:4464,x:31809,y:32186,varname:node_4464,prsc:2|A-5761-RGB,B-7851-RGB,T-5452-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:5735,x:31838,y:32497,varname:node_5735,prsc:2,chbt:0|M-9314-OUT,R-5215-OUT,G-719-OUT,B-3858-OUT,A-842-OUT;n:type:ShaderForge.SFN_Vector1,id:5452,x:31556,y:32342,varname:node_5452,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:5761,x:31573,y:32037,varname:node_5761,prsc:2,ntxv:0,isnm:False|TEX-3446-TEX;n:type:ShaderForge.SFN_Color,id:7851,x:31371,y:32251,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5147059,c2:0.5147059,c3:0.5147059,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:3446,x:31334,y:32020,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3446,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2396,x:31089,y:32333,varname:node_2396,prsc:2,ntxv:0,isnm:False|TEX-9330-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9330,x:30898,y:32333,ptovrint:False,ptlb:Splat00,ptin:_Splat00,varname:node_9330,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7997,x:31089,y:32529,varname:node_7997,prsc:2,ntxv:0,isnm:False|TEX-8574-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8574,x:30898,y:32529,ptovrint:False,ptlb:Splat10,ptin:_Splat10,varname:node_8574,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9345,x:31082,y:32717,varname:node_9345,prsc:2,ntxv:0,isnm:False|TEX-6820-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6820,x:30898,y:32730,ptovrint:False,ptlb:Splat20,ptin:_Splat20,varname:node_6820,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1996,x:31082,y:32924,varname:node_1996,prsc:2,ntxv:0,isnm:False|TEX-581-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:581,x:30898,y:32924,ptovrint:False,ptlb:Splast30,ptin:_Splast30,varname:node_581,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:9314,x:31046,y:31728,varname:node_9314,prsc:2|A-6485-RGB,B-6485-A;n:type:ShaderForge.SFN_Tex2d,id:6485,x:30842,y:31746,varname:node_6485,prsc:2,ntxv:0,isnm:False|TEX-5136-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5136,x:30687,y:31746,ptovrint:False,ptlb:Control,ptin:_Control,varname:node_5136,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ChannelBlend,id:1825,x:31312,y:31455,varname:node_1825,prsc:2,chbt:0|M-9314-OUT,R-8683-RGB,G-2484-RGB,B-1780-RGB,A-3389-RGB;n:type:ShaderForge.SFN_Tex2d,id:8683,x:30691,y:30932,varname:node_8683,prsc:2,ntxv:0,isnm:False|TEX-8018-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8018,x:30447,y:30882,ptovrint:False,ptlb:Normal0,ptin:_Normal0,varname:node_8018,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2484,x:30691,y:31084,varname:node_2484,prsc:2,ntxv:0,isnm:False|TEX-6575-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6575,x:30457,y:31119,ptovrint:False,ptlb:Normal1,ptin:_Normal1,varname:node_6575,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1780,x:30691,y:31230,varname:node_1780,prsc:2,ntxv:0,isnm:False|TEX-1605-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1605,x:30457,y:31280,ptovrint:False,ptlb:Normal2,ptin:_Normal2,varname:node_1605,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3389,x:30691,y:31424,varname:node_3389,prsc:2,ntxv:0,isnm:False|TEX-643-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:643,x:30457,y:31460,ptovrint:False,ptlb:Normal3,ptin:_Normal3,varname:node_643,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:1858,x:33223,y:33285,ptovrint:False,ptlb:outline width,ptin:_outlinewidth,varname:node_1858,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05553991,max:1;n:type:ShaderForge.SFN_Color,id:137,x:33158,y:33075,ptovrint:False,ptlb:Outlien Color,ptin:_OutlienColor,varname:node_137,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:9047,x:33036,y:32881,varname:node_9047,prsc:2,blmd:10,clmp:True|SRC-2189-OUT,DST-544-OUT;n:type:ShaderForge.SFN_Code,id:6506,x:30177,y:31929,varname:node_6506,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_6506,width:263,height:169,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:Tex,input_2_label:WorldPosition,input_3_label:ObjectPosition,input_4_label:NormalDirection,input_5_label:Detail,input_6_label:Scale|A-929-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-5417-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1489,x:29240,y:31959,ptovrint:False,ptlb:Detail,ptin:_Detail,varname:node_1489,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_NormalVector,id:7419,x:29251,y:31761,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:7944,x:29272,y:31433,varname:node_7944,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:4704,x:29262,y:31590,varname:node_4704,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5417,x:29240,y:32059,ptovrint:False,ptlb:ScaleTex0,ptin:_ScaleTex0,varname:node_5417,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:5215,x:30672,y:32316,varname:node_5215,prsc:2|A-409-RGB,B-6506-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:929,x:29825,y:31880,ptovrint:False,ptlb:Splat0,ptin:_Splat0,varname:node_929,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Code,id:5580,x:30174,y:32216,varname:node_5580,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_5580,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:Tex,input_2_label:WorldPosition,input_3_label:ObjectPosition,input_4_label:NormalDirection,input_5_label:Detail,input_6_label:Scale|A-6631-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-7313-OUT;n:type:ShaderForge.SFN_Code,id:9915,x:30139,y:32398,varname:node_9915,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_9915,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:Tex,input_2_label:WorldPosition,input_3_label:ObjectPosition,input_4_label:NormalDirection,input_5_label:Detail,input_6_label:Scale|A-7813-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-863-OUT;n:type:ShaderForge.SFN_Code,id:2664,x:30139,y:32590,varname:node_2664,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_2664,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:Tex,input_2_label:WorldPosition,input_3_label:ObjectPosition,input_4_label:NormalDirection,input_5_label:Detail,input_6_label:Scale|A-4362-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-7404-OUT;n:type:ShaderForge.SFN_Multiply,id:719,x:30672,y:32489,varname:node_719,prsc:2|A-5942-RGB,B-5580-OUT;n:type:ShaderForge.SFN_Multiply,id:3858,x:30689,y:32673,varname:node_3858,prsc:2|A-4983-RGB,B-9915-OUT;n:type:ShaderForge.SFN_Multiply,id:842,x:30689,y:32879,varname:node_842,prsc:2|A-8455-RGB,B-2664-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6631,x:29826,y:32167,ptovrint:False,ptlb:Splat1,ptin:_Splat1,varname:node_6631,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:7813,x:29815,y:32392,ptovrint:False,ptlb:Splat2,ptin:_Splat2,varname:node_7813,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:4362,x:29831,y:32585,ptovrint:False,ptlb:Splat3,ptin:_Splat3,varname:node_4362,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Code,id:1069,x:30121,y:30810,varname:node_1069,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_1069,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:D,input_5_label:E,input_6_label:F|A-8018-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-5417-OUT;n:type:ShaderForge.SFN_Code,id:3571,x:30121,y:31030,varname:node_3571,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_3571,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:D,input_5_label:E,input_6_label:F|A-6575-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-7313-OUT;n:type:ShaderForge.SFN_Code,id:5025,x:30121,y:31253,varname:node_5025,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_5025,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:D,input_5_label:E,input_6_label:F|A-1605-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-863-OUT;n:type:ShaderForge.SFN_Code,id:7910,x:30159,y:31460,varname:node_7910,prsc:2,code:ZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwAIAA9ACAAcABvAHcAKABhAGIAcwAoAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoAE4AbwByAG0AYQBsAEQAaQByAGUAYwB0AGkAbwBuACwAMAApACAAKQAuAHgAeQB6AC4AcgBnAGIAKQAsAEQAZQB0AGEAaQBsACkAOwANAAoAbABvAGMAYQBsAE4AbwByAG0AYQBsACAAPQAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAHIAZwBiACAALwAgACgAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AcgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgBnACAAKwAgAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKQA7AA0ACgANAAoAZgBsAG8AYQB0ADMAIABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuACAAPQAgAG0AdQBsACgAIABfAFcAbwByAGwAZAAyAE8AYgBqAGUAYwB0ACwAIABmAGwAbwBhAHQANAAoACgAVwBvAHIAbABkAFAAbwBzAGkAdABpAG8AbgAuAHIAZwBiAC0ATwBiAGoAZQBjAHQAUABvAHMAaQB0AGkAbwBuAC4AcgBnAGIAKQAsADAAKQAgACkALgByAGcAYgAvAFMAYwBhAGwAZQA7AA0ACgBmAGwAbwBhAHQANAAgAHQAZQB4ADEAIAA9ACAAdABlAHgAMgBEACgAVABlAHgALABsAG8AYwBhAGwAUABvAHMAaQB0AGkAbwBuAC4AcgBnACkAOwANAAoAZgBsAG8AYQB0ADQAIAB0AGUAeAAyACAAPQAgAHQAZQB4ADIARAAoAFQAZQB4ACwAbABvAGMAYQBsAFAAbwBzAGkAdABpAG8AbgAuAHIAYgApADsADQAKAGYAbABvAGEAdAA0ACAAdABlAHgAMwAgAD0AIAB0AGUAeAAyAEQAKABUAGUAeAAsAGwAbwBjAGEAbABQAG8AcwBpAHQAaQBvAG4ALgBnAGIAKQA7AA0ACgANAAoAcgBlAHQAdQByAG4AIAAoAGwAbwBjAGEAbABOAG8AcgBtAGEAbAAuAGIAKgB0AGUAeAAxAC4AcgBnAGIAIAArACAAbABvAGMAYQBsAE4AbwByAG0AYQBsAC4AZwAqAHQAZQB4ADIALgByAGcAYgAgACsAIABsAG8AYwBhAGwATgBvAHIAbQBhAGwALgByACoAdABlAHgAMwAuAHIAZwBiACkAOwA=,output:2,fname:Function_node_7910,width:247,height:168,input:12,input:2,input:2,input:2,input:0,input:0,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:D,input_5_label:E,input_6_label:F|A-643-TEX,B-7944-XYZ,C-4704-XYZ,D-7419-OUT,E-1489-OUT,F-7404-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7313,x:29240,y:32159,ptovrint:False,ptlb:ScaleTex1,ptin:_ScaleTex1,varname:node_7313,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:863,x:29240,y:32250,ptovrint:False,ptlb:ScaleTex2,ptin:_ScaleTex2,varname:node_863,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7404,x:29240,y:32351,ptovrint:False,ptlb:ScaleTex3,ptin:_ScaleTex3,varname:node_7404,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:409,x:29985,y:32976,ptovrint:False,ptlb:Color 0,ptin:_Color0,varname:node_409,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:5942,x:30138,y:32976,ptovrint:False,ptlb:Color 1,ptin:_Color1,varname:node_5942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:4983,x:30284,y:32976,ptovrint:False,ptlb:Color 2,ptin:_Color2,varname:node_4983,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:8455,x:30447,y:32976,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:node_8455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:7116,x:32607,y:33563,ptovrint:False,ptlb:Ambient Strenght,ptin:_AmbientStrenght,varname:node_7116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:6636,x:33781,y:32565,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_6636,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8332,x:33010,y:33491,varname:node_8332,prsc:2|A-7528-RGB,B-7116-RGB;n:type:ShaderForge.SFN_Slider,id:4377,x:33113,y:32644,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_4377,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:311,x:32820,y:33363,varname:node_311,prsc:2|A-3566-OUT,B-7116-RGB;proporder:6152-2501-7809-6253-7014-388-7851-3446-9330-8574-6820-581-5136-8018-6575-1605-643-1858-137-1489-5417-929-6631-7813-4362-7313-7404-863-409-5942-4983-8455-7116-6636-4377;pass:END;sub:END;*/

Shader "Shader Forge/customLit4" {
    Properties {
        _ShadowDarkness ("ShadowDarkness", Range(-5, 5)) = 0
        _Tones ("Tones", Float ) = 5
        _normalstrenght ("normal strenght", Range(0, 5)) = 0
        _rimlightmap ("rim light map", Cube) = "_Skybox" {}
        _freshnelstrenght ("freshnel strenght", Range(0, 10)) = 6.860362
        _reflectionstrength ("reflection strength", Range(0, 1)) = 0.1861916
        _Color ("Color", Color) = (0.5147059,0.5147059,0.5147059,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _Splat00 ("Splat00", 2D) = "white" {}
        _Splat10 ("Splat10", 2D) = "white" {}
        _Splat20 ("Splat20", 2D) = "white" {}
        _Splast30 ("Splast30", 2D) = "white" {}
        _Control ("Control", 2D) = "white" {}
        _Normal0 ("Normal0", 2D) = "white" {}
        _Normal1 ("Normal1", 2D) = "white" {}
        _Normal2 ("Normal2", 2D) = "white" {}
        _Normal3 ("Normal3", 2D) = "white" {}
        _outlinewidth ("outline width", Range(0, 1)) = 0.05553991
        _OutlienColor ("Outlien Color", Color) = (0.5,0.5,0.5,1)
        _Detail ("Detail", Float ) = 2
        _ScaleTex0 ("ScaleTex0", Float ) = 2
        _Splat0 ("Splat0", 2D) = "white" {}
        _Splat1 ("Splat1", 2D) = "white" {}
        _Splat2 ("Splat2", 2D) = "white" {}
        _Splat3 ("Splat3", 2D) = "white" {}
        _ScaleTex1 ("ScaleTex1", Float ) = 2
        _ScaleTex3 ("ScaleTex3", Float ) = 0
        _ScaleTex2 ("ScaleTex2", Float ) = 0
        _Color0 ("Color 0", Color) = (0.5,0.5,0.5,1)
        _Color1 ("Color 1", Color) = (0.5,0.5,0.5,1)
        _Color2 ("Color 2", Color) = (0.5,0.5,0.5,1)
        _Color3 ("Color3", Color) = (0.5,0.5,0.5,1)
        _AmbientStrenght ("Ambient Strenght", Color) = (0.5,0.5,0.5,1)
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 2.0
            uniform float _outlinewidth;
            uniform float4 _OutlienColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*_outlinewidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                return fixed4(_OutlienColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 2.0
            uniform float _ShadowDarkness;
            uniform float _Tones;
            uniform float _normalstrenght;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Control; uniform float4 _Control_ST;
            uniform sampler2D _Normal0; uniform float4 _Normal0_ST;
            uniform sampler2D _Normal1; uniform float4 _Normal1_ST;
            uniform sampler2D _Normal2; uniform float4 _Normal2_ST;
            uniform sampler2D _Normal3; uniform float4 _Normal3_ST;
            float3 Function_node_6506( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform float _Detail;
            uniform float _ScaleTex0;
            uniform sampler2D _Splat0; uniform float4 _Splat0_ST;
            float3 Function_node_5580( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_9915( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_2664( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform sampler2D _Splat1; uniform float4 _Splat1_ST;
            uniform sampler2D _Splat2; uniform float4 _Splat2_ST;
            uniform sampler2D _Splat3; uniform float4 _Splat3_ST;
            uniform float _ScaleTex1;
            uniform float _ScaleTex2;
            uniform float _ScaleTex3;
            uniform float4 _Color0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float4 _AmbientStrenght;
            uniform float _Specular;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_6485 = tex2D(_Control,TRANSFORM_TEX(i.uv0, _Control));
                float4 node_9314 = float4(node_6485.rgb,node_6485.a);
                float4 node_8683 = tex2D(_Normal0,TRANSFORM_TEX(i.uv0, _Normal0));
                float4 node_2484 = tex2D(_Normal1,TRANSFORM_TEX(i.uv0, _Normal1));
                float4 node_1780 = tex2D(_Normal2,TRANSFORM_TEX(i.uv0, _Normal2));
                float4 node_3389 = tex2D(_Normal3,TRANSFORM_TEX(i.uv0, _Normal3));
                float3 normalLocal = lerp((node_9314.r*node_8683.rgb + node_9314.g*node_2484.rgb + node_9314.b*node_1780.rgb + node_9314.a*node_3389.rgb),float3(0,0,1),_normalstrenght);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float4 node_5761 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_5452 = 1.0;
                float3 node_4464 = lerp(node_5761.rgb,_Color.rgb,node_5452);
                float3 node_544 = (lerp(node_4464,(node_9314.r*(_Color0.rgb*Function_node_6506( _Splat0 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex0 )) + node_9314.g*(_Color1.rgb*Function_node_5580( _Splat1 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex1 )) + node_9314.b*(_Color2.rgb*Function_node_9915( _Splat2 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex2 )) + node_9314.a*(_Color3.rgb*Function_node_2664( _Splat3 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex3 ))),node_5452)*node_4464); // Diffuse Color
                float3 BCol = node_544;
                float3 node_1515 = BCol;
                float lOut = max(0,dot(lightDirection,i.normalDir));
                float Tones = (_Tones-1.0);
                float node_3440 = Tones;
                float3 node_2189 = lerp(node_1515,((node_1515*((round((lOut*node_3440))/node_3440)*attenuation*_LightColor0.rgb))*_AmbientStrenght.rgb),_ShadowDarkness);
                float3 node_9047 = saturate(( node_544 > 0.5 ? (1.0-(1.0-2.0*(node_544-0.5))*(1.0-node_2189)) : (2.0*node_544*node_2189) ));
                float3 diffuseColor = node_9047;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 2.0
            uniform float _ShadowDarkness;
            uniform float _Tones;
            uniform float _normalstrenght;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Control; uniform float4 _Control_ST;
            uniform sampler2D _Normal0; uniform float4 _Normal0_ST;
            uniform sampler2D _Normal1; uniform float4 _Normal1_ST;
            uniform sampler2D _Normal2; uniform float4 _Normal2_ST;
            uniform sampler2D _Normal3; uniform float4 _Normal3_ST;
            float3 Function_node_6506( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform float _Detail;
            uniform float _ScaleTex0;
            uniform sampler2D _Splat0; uniform float4 _Splat0_ST;
            float3 Function_node_5580( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_9915( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_2664( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform sampler2D _Splat1; uniform float4 _Splat1_ST;
            uniform sampler2D _Splat2; uniform float4 _Splat2_ST;
            uniform sampler2D _Splat3; uniform float4 _Splat3_ST;
            uniform float _ScaleTex1;
            uniform float _ScaleTex2;
            uniform float _ScaleTex3;
            uniform float4 _Color0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float4 _AmbientStrenght;
            uniform float _Specular;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_6485 = tex2D(_Control,TRANSFORM_TEX(i.uv0, _Control));
                float4 node_9314 = float4(node_6485.rgb,node_6485.a);
                float4 node_8683 = tex2D(_Normal0,TRANSFORM_TEX(i.uv0, _Normal0));
                float4 node_2484 = tex2D(_Normal1,TRANSFORM_TEX(i.uv0, _Normal1));
                float4 node_1780 = tex2D(_Normal2,TRANSFORM_TEX(i.uv0, _Normal2));
                float4 node_3389 = tex2D(_Normal3,TRANSFORM_TEX(i.uv0, _Normal3));
                float3 normalLocal = lerp((node_9314.r*node_8683.rgb + node_9314.g*node_2484.rgb + node_9314.b*node_1780.rgb + node_9314.a*node_3389.rgb),float3(0,0,1),_normalstrenght);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_5761 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_5452 = 1.0;
                float3 node_4464 = lerp(node_5761.rgb,_Color.rgb,node_5452);
                float3 node_544 = (lerp(node_4464,(node_9314.r*(_Color0.rgb*Function_node_6506( _Splat0 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex0 )) + node_9314.g*(_Color1.rgb*Function_node_5580( _Splat1 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex1 )) + node_9314.b*(_Color2.rgb*Function_node_9915( _Splat2 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex2 )) + node_9314.a*(_Color3.rgb*Function_node_2664( _Splat3 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex3 ))),node_5452)*node_4464); // Diffuse Color
                float3 BCol = node_544;
                float3 node_1515 = BCol;
                float lOut = max(0,dot(lightDirection,i.normalDir));
                float Tones = (_Tones-1.0);
                float node_3440 = Tones;
                float3 node_2189 = lerp(node_1515,((node_1515*((round((lOut*node_3440))/node_3440)*attenuation*_LightColor0.rgb))*_AmbientStrenght.rgb),_ShadowDarkness);
                float3 node_9047 = saturate(( node_544 > 0.5 ? (1.0-(1.0-2.0*(node_544-0.5))*(1.0-node_2189)) : (2.0*node_544*node_2189) ));
                float3 diffuseColor = node_9047;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 2.0
            uniform float _ShadowDarkness;
            uniform float _Tones;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Control; uniform float4 _Control_ST;
            float3 Function_node_6506( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform float _Detail;
            uniform float _ScaleTex0;
            uniform sampler2D _Splat0; uniform float4 _Splat0_ST;
            float3 Function_node_5580( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_9915( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            float3 Function_node_2664( sampler2D Tex , float3 WorldPosition , float3 ObjectPosition , float3 NormalDirection , float Detail , float Scale ){
            float3 localNormal = pow(abs(mul( unity_WorldToObject, float4(NormalDirection,0) ).xyz.rgb),Detail);
            localNormal = localNormal.rgb / (localNormal.r + localNormal.g + localNormal.b);
            
            float3 localPosition = mul( unity_WorldToObject, float4((WorldPosition.rgb-ObjectPosition.rgb),0) ).rgb/Scale;
            float4 tex1 = tex2D(Tex,localPosition.rg);
            float4 tex2 = tex2D(Tex,localPosition.rb);
            float4 tex3 = tex2D(Tex,localPosition.gb);
            
            return (localNormal.b*tex1.rgb + localNormal.g*tex2.rgb + localNormal.r*tex3.rgb);
            }
            
            uniform sampler2D _Splat1; uniform float4 _Splat1_ST;
            uniform sampler2D _Splat2; uniform float4 _Splat2_ST;
            uniform sampler2D _Splat3; uniform float4 _Splat3_ST;
            uniform float _ScaleTex1;
            uniform float _ScaleTex2;
            uniform float _ScaleTex3;
            uniform float4 _Color0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float4 _AmbientStrenght;
            uniform float _Specular;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 node_5761 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_5452 = 1.0;
                float3 node_4464 = lerp(node_5761.rgb,_Color.rgb,node_5452);
                float4 node_6485 = tex2D(_Control,TRANSFORM_TEX(i.uv0, _Control));
                float4 node_9314 = float4(node_6485.rgb,node_6485.a);
                float3 node_544 = (lerp(node_4464,(node_9314.r*(_Color0.rgb*Function_node_6506( _Splat0 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex0 )) + node_9314.g*(_Color1.rgb*Function_node_5580( _Splat1 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex1 )) + node_9314.b*(_Color2.rgb*Function_node_9915( _Splat2 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex2 )) + node_9314.a*(_Color3.rgb*Function_node_2664( _Splat3 , i.posWorld.rgb , objPos.rgb , i.normalDir , _Detail , _ScaleTex3 ))),node_5452)*node_4464); // Diffuse Color
                float3 BCol = node_544;
                float3 node_1515 = BCol;
                float lOut = max(0,dot(lightDirection,i.normalDir));
                float Tones = (_Tones-1.0);
                float node_3440 = Tones;
                float3 node_2189 = lerp(node_1515,((node_1515*((round((lOut*node_3440))/node_3440)*attenuation*_LightColor0.rgb))*_AmbientStrenght.rgb),_ShadowDarkness);
                float3 node_9047 = saturate(( node_544 > 0.5 ? (1.0-(1.0-2.0*(node_544-0.5))*(1.0-node_2189)) : (2.0*node_544*node_2189) ));
                float3 diffColor = node_9047;
                float3 specColor = float3(_Specular,_Specular,_Specular);
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
