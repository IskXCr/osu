﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Android.Content.PM;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Game;

namespace osu.Android
{
    public class GameplayScreenRotationLocker : Component
    {
        private Bindable<bool> localUserPlaying;

        [BackgroundDependencyLoader]
        private void load(OsuGame game)
        {
            localUserPlaying = game.LocalUserPlaying.GetBoundCopy();
            localUserPlaying.ValueChanged += updateLock;
        }

        private void updateLock(ValueChangedEvent<bool> userPlaying)
        {
            OsuGameActivity.Activity.RunOnUiThread(() =>
            {
                OsuGameActivity.Activity.RequestedOrientation = userPlaying.NewValue ? ScreenOrientation.Locked : ScreenOrientation.FullUser;
            });
        }
    }
}
