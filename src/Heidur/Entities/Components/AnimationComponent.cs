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

        public AnimationComponent(SpriteComponent spriteComponent, int IdleFramesLength, int WalkingFramesLength, int AttackFramesLength)
        {
            Clock = new Clock();
            this.FramesLength = new int[Constants.Animation.FRAME_CATEGORIES] { WalkingFramesLength, WalkingFramesLength, WalkingFramesLength, WalkingFramesLength, IdleFramesLength, AttackFramesLength };
            this.frameArray = AnimationProcessor.CraftAnimationLists(this, spriteComponent);
            CurrentCategory = (int) Constants.Animation.FrameCategory.IDLE;
            CurrentFrame = 0;
        }
    }
}
