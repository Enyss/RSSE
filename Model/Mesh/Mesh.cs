using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using NLua;

namespace RSSE
{
    public class Mesh
    {

        // General
        public string name;
        public string model;
        public MeshTypeEnum meshType;
        public string systemType;
        public string uiName;
        public string sectionName;

        // Position
        public Vec3 position;
        public Vec3 rotation;

        public string parentName;
        public Mesh parent;
        public List<Mesh> children;

        // Interaction
        public double PickSphereRADIUS;



        // Collision
        public  MeshCollisionData collision;

        // Render
        public MeshRenderData render;

        // Light
        public MeshLightData light;

        // States
        public MeshStatesData states;

        //Surfaces
        public MeshSurfacesData surfaces;

        public Mesh()
        {
            name = "default";
            children = new List<Mesh>();
            render = new MeshRenderData();
            collision = new MeshCollisionData();
            //Light
            light = new MeshLightData();
            //States 
            states = new MeshStatesData();
            //Surfaces
            surfaces = new MeshSurfacesData();
        }

        public Mesh(Table table)
        {
            children = new List<Mesh>();

            //General
            name                = table["Name"].StrValue;
            model               = table["Model"].StrValue;
            meshType            = MeshTypeEnumExtensions.TypeFromString( table["SpecialObjectName"].StrValue );
            systemType          = table["SystemType"].StrValue;
            sectionName         = table["SectionName"].StrValue;
            uiName              = table["UIName"].StrValue;


            //Interaction
            PickSphereRADIUS    = table["PickSphereRADIUS"].DoubleValue;

            //Position
            parentName = table["ParentTo"].StrValue;
            position = new Vec3(table["Position"]);
            rotation = new Vec3(table["Rotation"]);
            //Collision


            //Render
            render = new MeshRenderData(table);
            collision = new MeshCollisionData(table);
            //Light
            //light = new MeshLightData(table);

            //States 
            states = new MeshStatesData(table);

            //Surfaces
            surfaces = new MeshSurfacesData(table);
        }

        public Table ToTable()
        {
            Table table = new Table();

            //General
            table["Name"].Value = name;
            if ( model != "")
                table["Model"].Value = model;
            table["SpecialObjectName"].Value = MeshTypeEnumExtensions.StringFromType(meshType);
            table["SystemType"].Value = systemType;
            table["SectionName"].Value = sectionName;
            table["UIName"].Value = uiName;

            //


            table["ParentTo"].Value = (parent==null)?"NONE":parent.name;
            table["Position"] = position.ToTable();
            table["Rotation"] = rotation.ToTable();

            //Interaction
            table["PickSphereRADIUS"].Value = PickSphereRADIUS;

            //Render
            render.AddToTable(table);
            //light.AddToTable(table);

            //States 
            states.AddToTable(table);

            //Surfaces
            surfaces.AddToTable(table);

            return table;
        }

        public void LinkToParent(List<Mesh> list)
        {
            Mesh mesh = list.Find(x => (x.name == parentName) );
            if (mesh != null)
            {
                parent = mesh;
                if (!mesh.children.Contains(this))
                {
                    mesh.children.Add(this);
                }
            }
        }
    }

}
