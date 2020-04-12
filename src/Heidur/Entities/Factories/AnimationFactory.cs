using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Heidur.Helpers;

namespace Heidur.Entities.Factories
{
	public static class AnimationFactory
	{
		public static AnimationComponent GetNewAnimationComponent(SpriteComponent spriteComponent)
		{
			var animationComponent = new AnimationComponent()
			{
				Clock = new Clock(),
				FramesLength = new int[Constants.Animation.FRAME_CATEGORIES]
					{
						Constants.Animation.DEFAULT_FRAMES_WALKING,
						Constants.Animation.DEFAULT_FRAMES_WALKING,
						Constants.Animation.DEFAULT_FRAMES_WALKING,
						Constants.Animation.DEFAULT_FRAMES_WALKING
					},
				CurrentCategory = (int)Constants.Animation.FrameCategory.WALKING_S,
				CurrentFrame = 0,
				FullAnimation = false
			};

			animationComponent.frameArray = AnimationProcessor.CraftAnimationLists(animationComponent, spriteComponent);

			return animationComponent;
		}
	}
}
