using System;
using System.Collections.Generic;
using Antlr.StringTemplate;
using DSIS.CellImageBuilder.Shared;
using DSIS.CodeCompiler;
using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.CellImageBuilder.Descartes;	
using DSIS.Utils;

[$AttributeMarker$]
public class DescartesCellImageBuilder$Key$ : IntegerCoordinateMethodBase<$CellType$, DescartesSettings>, ICellImageBuilder<$CellType$> 
{
    private readonly ISystemSpaceFactory mySpaceFactory;
    private readonly GeneratedIntegerCoordinateSystemManager myManager;
    
    $ICS:{ private $it.Type$ $it.Name$; }$
    $ICS:{ private readonly $it.FactoryType$ $it.FactoryName$; }$
    $ICS:{ private $it.BuilderType$ $it.BuilderName$; }$
    private DescartesSettings mySettings;
    
    public DescartesCellImageBuilder$Key$(ISystemSpaceFactory factory, GeneratedIntegerCoordinateSystemManager manager ) {
       try {
		  $ICS:{ this.$it.FactoryName$ = ($it.FactoryType$)manager.CreateSystem($it.Dimension$); }$	
	   } catch (Exception e) {
			throw new Exception("GeneratedIntegerCoordinateSystemManager should reuse generated integer coordinate systems by dimension", e);
	   }
	   mySpaceFactory = factory;
	   myManager = manager;
    }
  
    protected override void Bind(DescartesSettings settings, CellImageBuilderContext<$CellType$> context)
    {
      var systemInfo = context.Function as ISplittableSystemInfo;

      if (systemInfo == null)
      {
        throw new Exception("Failed to create Decartes method for non-splittable system function");
      }
      $ICS:{ $it.Name$ = CreateSystem$it.Index$(mySystem);  }$
      $ICS:{ $it.BuilderName$ = settings.Builders[$it.Index$].Settings.Create<$it.CellType$>(); }$
    }
    
    $ICS:{
    
    private $it.Type$ CreateSystem$it.Index$(IIntegerCoordinateSystem system) {
      double[] left  = new double[] { $it.Coords:{ system.SystemSpace.AreaLeftPoint[$it.Index$] }; separator=", "$};
      double[] right = new double[] { $it.Coords:{ system.SystemSpace.AreaRightPoint[$it.Index$] }; separator=", "$};
      long[]   grid  = new long[]   { $it.Coords:{ system.Subdivision[$it.Index$] }; separator=", "$};
      var space = mySpaceFactory.CreateSpace($it.Dimension$, left, right, grid);
      
      return $it.FactoryName$.CreateEx(space, grid);    
    }
    
    }$

    public override void BuildImage($CellType$ coord)
    {
      $ICS:{
       {
         $it.CellType$ p = $it.Name$.Create( $it.Coords:{ coord.$it.BaseName$ };separator=","$);         
       }
      }$
    }

    public override ICellImageBuilder<$CellType$> Clone()
    {
      return new DescartesCellImageBuilder$Key$(mySpaceFactory, myManager	);	
    }
  }