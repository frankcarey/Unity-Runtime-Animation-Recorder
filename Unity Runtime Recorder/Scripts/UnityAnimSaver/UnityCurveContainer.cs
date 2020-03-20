using UnityEngine;
using System.Collections;
using System;

public class UnityCurveContainer {

	public string propertyName = "";
	public AnimationCurve animCurve;

	public UnityCurveContainer( string _propertyName ) {
		animCurve = new AnimationCurve ();
		propertyName = _propertyName;
	}

	public void AddValue( float animTime, float animValue )
	{
		// If this is close to the same value as last time, don't record it.
		var last = animCurve.length - 1;
		if (last > -1)
		{
			var lastFrame = animCurve[last];
			if (Math.Abs(lastFrame.value - animValue) < 0.01)
			{
				return;
			}
		}
		// Otherwise record a new key.
		Keyframe key = new Keyframe (animTime, animValue, 0.0f, 0.0f);
		animCurve.AddKey (key);
	}
}
