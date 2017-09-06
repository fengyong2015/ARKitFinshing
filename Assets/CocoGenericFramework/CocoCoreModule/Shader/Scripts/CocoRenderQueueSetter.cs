using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

namespace CocoPlay
{
	#if !UNITY_5_4_OR_NEWER
	public enum RenderQueue
	{
		Background = 1000,
		Geometry = 2000,
		AlphaTest = 2450,
		GeometryLast = 2500,
		Transparent = 3000,
		Overlay = 4000
	}
	#endif

	public class CocoRenderQueueSetter : MonoBehaviour
	{

		[SerializeField]
		bool m_ExecuteOnStart = true;

		void Start ()
		{
			if (m_ExecuteOnStart) {
				Execute ();
			}
		}


		#region Material

		[SerializeField]
		Material m_TargetMaterial = null;

		public Material TargetMaterial {
			get {
				if (m_TargetMaterial == null) {
					Renderer renderer = GetComponent<Renderer> ();
					if (renderer != null) {
						m_TargetMaterial = renderer.material;
					}
				}
				return m_TargetMaterial;
			}
		}

		#endregion


		#region Queue

		[SerializeField]
		CocoRenderQueue m_TargetQueue = new CocoRenderQueue (RenderQueue.Transparent);

		public CocoRenderQueue TargetQueue {
			get {
				return m_TargetQueue;
			}
		}

		public void SetQueue (RenderQueue queue, int offset)
		{
			m_TargetQueue = new CocoRenderQueue (queue, offset);

			Execute ();
		}

		[ContextMenu ("Execute")]
		public void Execute ()
		{
			if (TargetMaterial == null) {
				return;
			}
				
			TargetMaterial.renderQueue = TargetQueue.Value;
		}

		#endregion
	}

	[System.Serializable]
	public class CocoRenderQueue
	{
		public CocoRenderQueue (RenderQueue queue, int offset = 0)
		{
			Set (queue, offset);
		}

		public void Set (RenderQueue queue, int offset = 0)
		{
			m_Queue = queue;
			m_Offset = offset;
		}

		[SerializeField]
		RenderQueue m_Queue;

		public RenderQueue Queue {
			get {
				return m_Queue;
			}
		}

		[SerializeField]
		int m_Offset;

		public int Offset {
			get {
				return m_Offset;
			}
		}

		public int Value {
			get {
				return GetQueueValue (m_Queue) + m_Offset;
			}
		}

		public static int GetQueueValue (RenderQueue queue)
		{
			switch (queue) {
			case RenderQueue.Background:
				return 1000;
			case RenderQueue.Overlay:
				return 4000;
			case RenderQueue.AlphaTest:
				return 2450;
			case RenderQueue.Transparent:
				return 3000;
			}

			return 2000;	// Geometry
		}
	}

}
