using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditorInternal;
public class ComponentCopyUtility {

	public static void CopyComponentAsNew<T>(GameObject origin, GameObject target) where T : Component
	{
		UnityEditorInternal.ComponentUtility.CopyComponent(origin.GetComponent<T>());
		UnityEditorInternal.ComponentUtility.PasteComponentAsNew(target);
	}

}
