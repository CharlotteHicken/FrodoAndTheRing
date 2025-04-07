using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DoesFrodoHaveRingCT : ConditionTask {

		public BBParameter<GameObject> frodo;
		public BBParameter<GameObject> ring;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (ring.value.transform.parent == frodo.value.transform) //if the ring has a parent that is frodo
			{
                return true;
            }
			else
			{
				return false;
			}
		}
	}
}