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
    $ICS:{ private $it.ConnectionType$ $it.ConnectionName$; }$
    private DescartesSettings mySettings;
    private new $SystemType$ mySystem;
    private new $BuilderType$ myBuilder;
    
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
      mySettings = settings;
      var systemInfo = context.Function as ISplittableSystemInfo;
      mySystem = ($SystemType$)base.mySystem;

      if (systemInfo == null)
      {
        throw new Exception("Failed to create Decartes method for non-splittable system function");
      }
      $ICS:{ $it.Name$ = CreateSystem$it.Index$(mySystem);  }$
      $ICS:{ $it.BuilderName$ = settings.Builders[$it.Index$].Settings.Create<$it.CellType$>(); }$
      $ICS:{ $it.ConnectionName$ = new $it.ConnectionType$(); }$
      $ICS:{ InitCellImageBuilder$it.Index$(systemInfo); }$
      
      myBuilder = ($BuilderType$)context.ConnectionBuilder;
    }
    
    $ICS:{
    private void InitCellImageBuilder$it.Index$(ISplittableSystemInfo system) {
      ISystemInfo sys = system.ForRange($it.IndexFrom$, $it.IndexTo$);
      ICellImageBuilderSettings settings = mySettings.Builders[$it.Index$].Settings	;
      $it.Type$ ics = $it.Name$;
      $it.ConnectionType$ connection = $it.ConnectionName$;
      
      $it.BuilderName$.Bind(new $it.ContextType$(sys, settings, ics, connection));
    }	
    
    }$
    
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
         $it.ConnectionName$.Clear();
         $it.CellType$ p = $it.Name$.Create( $it.Coords:{ coord.$it.BaseName$ };separator=","$);
         $it.BuilderName$.BuildImage(p);   
         
         //One component is empty => nothing to build
         if ($it.ConnectionName$.IsEmpty) return;      
       }
      }$
      
      $ICS:{
        foreach(var $it.Comp$ in $it.ConnectionName$.Values)
      }$
      { 
        $CellType$ from = mySystem.Create(
          $ICS:{ 
             $it.Coords:{ c | $it.Comp$.Key.$c.SelfComponent$ };separator=", "$ 
          };separator=", "$
        );
        
        List<$CellType$> list = new List<$CellType$>();
        
        $ICS:{
         foreach(var $it.Comp2$ in $it.Comp$.Value)
        }$
        
        {
          $CellType$ to = mySystem.Create(
            $ICS:{	 
               $it.Coords:{ c | $it.Comp2$.$c.SelfComponent$ };separator=", "$ 
            };separator=", "$
          );
          list.Add(to);
        }
        
        myBuilder.ConnectToMany(from, list);
      }			
    }

    public override ICellImageBuilder<$CellType$> Clone()
    {
      return new DescartesCellImageBuilder$Key$(mySpaceFactory, myManager);	
    }
  }