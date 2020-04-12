using Heidur.Entities.Processors;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Heidur.Entities.Components
{
    public class AnimationComponent
    {
        public float framesSpeed = Constants.Animation.DEFAULT_FRAMES_SPEED_MS;

        public Clock Clock { get; set; }
        public int[] FramesLength { get; set; }
		public List<Rectangle>[] frameArray { get; set; }

		public int CurrentCategory { get; set; }
		public int CurrentFrame { get; set; }
		public bool FullAnimation { get; set; }
	}
}
