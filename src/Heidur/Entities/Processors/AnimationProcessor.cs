using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using static Heidur.Constants.Animation;

namespace Heidur.Entities.Processors
{
    public static class AnimationProcessor
    {
        public static List<Rectangle>[] CraftAnimationLists(AnimationComponent animationComponent, SpriteComponent spriteComponent)
        {
            var result = new List<Rectangle>[FRAME_CATEGORIES];

            result[(int)FrameCategory.IDLE]= ObtainFrameList(FrameCategory.IDLE, spriteComponent, animationComponent);
            result[(int)FrameCategory.WALKING] = ObtainFrameList(FrameCategory.WALKING, spriteComponent, animationComponent);
            result[(int)FrameCategory.ATTACK] = ObtainFrameList(FrameCategory.ATTACK, spriteComponent, animationComponent);

            return result;
        }

        private static List<Rectangle> ObtainFrameList(FrameCategory frameCategory, SpriteComponent spriteComponent, AnimationComponent animationComponent)
        {
            var result = new List<Rectangle>();

            var textureSizeModified = Constants.TILESIZE * spriteComponent.textureModifier;

            for (int i = 0; i < animationComponent.FramesLength[(int)frameCategory]; i++)
            {
                Rectangle frame = new Rectangle(i * textureSizeModified, (int) frameCategory * textureSizeModified, textureSizeModified, textureSizeModified);
                result.Add(frame);
            }

            return result;
        }

        public static Rectangle GetFrame(AnimationComponent animationComponent)
        {
            return animationComponent.frameArray[animationComponent.CurrentCategory].ElementAt(animationComponent.CurrentFrame);
        }

        public static void Update(AnimationComponent animationComponent, float deltaTime)
        {
            if (animationComponent.Clock.isIntervalTicked(DEFAULT_FRAMES_SPEED_MS))
            {
                animationComponent.CurrentFrame++;
                if (animationComponent.CurrentFrame >= animationComponent.FramesLength[animationComponent.CurrentCategory])
                {
                    animationComponent.CurrentFrame = 0;
                }
            }

            animationComponent.Clock.Update(deltaTime);
        }

        public static void SwitchToFrameCategory(AnimationComponent animationComponent, FrameCategory frameCategory)
        {
            if (!animationComponent.CurrentCategory.Equals((int)frameCategory))
            {
                animationComponent.CurrentCategory = (int)frameCategory;
                animationComponent.CurrentFrame = 0;
            }
        }

        public static void SwitchToFrameCategory(GameObject player)
        {
            if ( player.physicsComponent.Up ||
                player.physicsComponent.Down ||
                player.physicsComponent.Left ||
                player.physicsComponent.Right )
            {
                if (!player.spriteComponent.AnimationComponent.CurrentCategory.Equals((int)FrameCategory.WALKING))
                {
                    player.spriteComponent.AnimationComponent.CurrentCategory = (int)FrameCategory.WALKING;
                    player.spriteComponent.AnimationComponent.CurrentFrame = 0;
                }
            }
            else
            {
                if (!player.spriteComponent.AnimationComponent.CurrentCategory.Equals((int)FrameCategory.IDLE))
                {
                    player.spriteComponent.AnimationComponent.CurrentCategory = (int)FrameCategory.IDLE;
                    player.spriteComponent.AnimationComponent.CurrentFrame = 0;
                }
            }
        }
    }
}
