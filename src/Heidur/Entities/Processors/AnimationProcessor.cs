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

            result[(int)FrameCategory.WALKING_N] = ObtainFrameList(FrameCategory.WALKING_N, spriteComponent, animationComponent);
            result[(int)FrameCategory.WALKING_S] = ObtainFrameList(FrameCategory.WALKING_S, spriteComponent, animationComponent);
            result[(int)FrameCategory.WALKING_E] = ObtainFrameList(FrameCategory.WALKING_E, spriteComponent, animationComponent);
            result[(int)FrameCategory.WALKING_W] = ObtainFrameList(FrameCategory.WALKING_W, spriteComponent, animationComponent);

            return result;
        }

        private static List<Rectangle> ObtainFrameList(FrameCategory frameCategory, SpriteComponent spriteComponent, AnimationComponent animationComponent)
        {
            var result = new List<Rectangle>();

            var textureSizeModified = Constants.TILESIZE * spriteComponent.TextureModifier;

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
                    animationComponent.FullAnimation = false;
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
            if (!player.spriteComponent.AnimationComponent.FullAnimation)
            {
                if (player.physicsComponent.IsMoving)

                {
                    switch (player.physicsComponent.FacingDirection)
                    {
                        case Constants.Physics.FacingDirections.UP:
                            InnerSwitchToCategory(player, FrameCategory.WALKING_N);
                            break;
                        case Constants.Physics.FacingDirections.DOWN:
                            InnerSwitchToCategory(player, FrameCategory.WALKING_S);
                            break;
                        case Constants.Physics.FacingDirections.LEFT:
                            InnerSwitchToCategory(player, FrameCategory.WALKING_E);
                            break;
                        case Constants.Physics.FacingDirections.RIGHT:
                            InnerSwitchToCategory(player, FrameCategory.WALKING_W);
                            break;
                    }
                }
                else
                {
                    player.spriteComponent.AnimationComponent.CurrentFrame = 0;
                }
            }
        }

        private static void InnerSwitchToCategory(GameObject player, FrameCategory frameCategory)
        {
            if (!player.spriteComponent.AnimationComponent.CurrentCategory.Equals((int)frameCategory))
            {
                player.spriteComponent.AnimationComponent.CurrentCategory = (int)frameCategory;
                player.spriteComponent.AnimationComponent.CurrentFrame = 0;
            }
        }

        public static void ExecuteFullAnimation(GameObject player, FrameCategory frameCategory)
        {
            player.spriteComponent.AnimationComponent.FullAnimation = true;
            InnerSwitchToCategory(player, frameCategory);
            player.spriteComponent.AnimationComponent.CurrentFrame = 0;
        }
    }
}
