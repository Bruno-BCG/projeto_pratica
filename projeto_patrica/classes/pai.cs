﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Pai
	{
		protected int id;

		public Pai()
		{
			id = 0;
		}
		public Pai(int id)
		{
			this.id = id;
		}

		public int Id { get; set; }
	}
}
