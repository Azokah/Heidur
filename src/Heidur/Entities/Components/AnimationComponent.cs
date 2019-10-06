using Heidur.Entities.Processors;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Heidur.Entities.Components
{
    public class AnimationComponent
    {
        public float framesSpeed = Constants.Animation.DEFAULT_FRAMES_SPEED_MS;

        public Clock Clock;
        public int[] FramesLength;
        public List<Rectangle>[] frameArray;

        public int CurrentCategory;
        public int CurrentFrame;
        public bool FullAnimation;

        public AnimationComponent(SpriteComponent spriteComponent,int WalkingFramesLength)
        {
            Clock = new Clock();
            this.FramesLength = new int[Constants.Animation.FRAME_CATEGORIES] { WalkingFramesLength, WalkingFramesLength, WalkingFramesLength, WalkingFramesLength };
            this.frameArray = AnimationProcessor.CraftAnimationLists(this, spriteComponent);
            CurrentCategory = (int) Constants.Animation.FrameCategory.WALKING_S;
            CurrentFrame = 0;
            FullAnimation = false;
        }
    }
}
