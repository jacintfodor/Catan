using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    public class Goods
    {
        private Dictionary<ResourceEnum, int>? _goods;

        public int Crop { get => _goods[ResourceEnum.Crop]; }
        public int Ore { get => _goods[ResourceEnum.Ore]; }
        public int Wood { get => _goods[ResourceEnum.Wood]; }
        public int Brick { get => _goods[ResourceEnum.Brick]; }
        public int Wool { get => _goods[ResourceEnum.Wool]; }


        public Goods(List<int> l)
        {
            if (l.Count != 5) throw new InvalidDataException("mismatching list count");
            if (!l.TrueForAll(n => n >= 0)) throw new InvalidDataException("negative");


            foreach (ResourceEnum resource in Enum.GetValues(typeof(ResourceEnum)))
            {
                if ((int)resource > (int)ResourceEnum.Desert)
                {
                    _goods[resource] = l[(int)resource];
                }
            }
        }

        public Goods() : this(Enumerable.Repeat(0, 5).ToList())
        {
        }

        public Goods(ResourceEnum e) : this(ResourceEnumToList(e)) { }

        //Crop, Ore, Wood, Brick, Wool
        public static Goods operator +(Goods a, Goods b)
        => new Goods(new List<int>() {
                a.Crop + b.Crop,
                a.Ore + b.Ore,
                a.Wood + b.Wood,
                a.Brick + b.Brick,
                a.Wool + b.Wool
        });

        public static Goods operator *(Goods a, int b)
        => new Goods(new List<int>() {
                a.Crop * b,
                a.Ore * b,
                a.Wood * b,
                a.Brick * b,
                a.Wool * b
        });

        public static Goods operator -(Goods a, Goods b)
        => new Goods(new List<int>() {
                a.Crop - b.Crop,
                a.Ore - b.Ore,
                a.Wood - b.Wood,
                a.Brick - b.Brick,
                a.Wool - b.Wool
        });


        private static List<int> ResourceEnumToList(ResourceEnum e)
        {
            List<int> result = new List<int>();
            foreach (ResourceEnum resource in Enum.GetValues(typeof(ResourceEnum)))
            {
                if ((int)resource > (int)ResourceEnum.Desert)
                {
                    if (e != resource)
                        result.Add(0);
                    else
                        result.Add(1);
                }
            }

            return result;
        }
    }
}
