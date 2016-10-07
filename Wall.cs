﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class Wall
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int owner_id { get; set; }
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
    /*    public List<CopyHistory> copy_history { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
        public List<Attachment2> attachments { get; set; }
        public Geo geo { get; set; }*/
    }

    public class WallResponse
    {
        public int count { get; set; }
        public List<Wall> items { get; set; }
    }

    public class RootWall
    {
        public WallResponse response { get; set; }
    }
}
