using System;
using System.Collections.Generic;
using System.Text;

namespace LB3
{
    partial class Table
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Table tbl = obj as Table; // возвращает null, если объект нельзя привести к типу Table
            if (tbl == null)//
                return false;

            return (this.model == tbl.model) && (this.height == tbl.height) && (this.width == tbl.width) && (this.depth == tbl.depth) && (this.price == tbl.price);
        }

        public override int GetHashCode()
        {
           
            int hash = this.depth + this.price + this.width + this.height + this.price;
            foreach (char i in this.model)
            {
                hash += (int)i;
            }
            return hash;
        }
        public override string ToString()
        {
            return $"Модель = {this.model} \nВысота = {this.height} \nШирина = {this.width} \nГлубина = {this.depth}\nЦена = {this.price}";
        }
    }
}
