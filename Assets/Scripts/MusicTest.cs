using UnityEngine;
using System.Collections;

public class MusicTest : MonoBehaviour {

	public AudioClip audio;
	public int scale =1;
	public int chan = 0;
	private AudioSource mySource;
	float [] samples = new float[1000]; 
	GameObject[] cubes = new GameObject[1000];
	GameObject [] cube0 = new GameObject[100];
	GameObject [] cube1 = new GameObject[100];
	GameObject [] cube2 = new GameObject[100];
	GameObject [] cube3 = new GameObject[100];

	void Start (){
		mySource = gameObject.AddComponent<AudioSource>();
		mySource.clip = audio;
		mySource.Play ();
		mySource.dopplerLevel = 0;
		mySource.rolloffMode = AudioRolloffMode.Linear;
		for (int i = 0; i < cubes.Length; i++) {
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i].transform.position = new Vector3(i,50,0);
		}
		for (int i = 0; i < cube0.Length; i++) {
			cube0[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube0[i].transform.position = new Vector3(i,0,0);
		}
		for (int i = 0; i < cube1.Length; i++) {
			cube1[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube1[i].transform.position = new Vector3(i,0,1);
		}
		for (int i = 0; i < cube2.Length; i++) {
			cube2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube2[i].transform.position = new Vector3(i,0,2);
		}
		for (int i = 0; i < cube3.Length; i++) {
			cube3[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube3[i].transform.position = new Vector3(i,0,3);
		}
		Debug.Log (audio.samples);
		StartCoroutine (playme ());
	}
	void Update() {
//		float[] spectrum = mySource.GetSpectrumData(1024, 0, FFTWindow.Rectangular);
//		int i = 1;
//		while (i < 1023) {
//			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
//			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
//			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
//			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
//			i++;
//		}
	}


	IEnumerator playme(){
		while (true) {
			mySource.GetOutputData (samples, chan);
			for (int i = 0; i < cubes.Length; i++) {
				cubes[i].transform.position = new Vector3(i, samples[i]*scale + 50,1);
				cubes[i].renderer.material.color = Color.cyan;
			}
			float[] spectrum = mySource.GetSpectrumData(1024, 0, FFTWindow.Hanning);
			for (int i = 0; i < cube0.Length; i++) {
				cube0 [i].transform.position = new Vector3(i, spectrum [i]*scale,0);
				cube0[i].renderer.material.color = Color.red;
			}
			spectrum = mySource.GetSpectrumData(1024, 0, FFTWindow.Triangle);
			for (int i = 0; i < cube1.Length; i++) {
				cube1 [i].transform.position = new Vector3(i+100, spectrum [i]*scale,1);
				cube1[i].renderer.material.color = Color.green;
			}
			spectrum = mySource.GetSpectrumData(1024, 0, FFTWindow.Hamming);
			for (int i = 0; i < cube2.Length; i++) {
				cube2 [i].transform.position = new Vector3(i+200, spectrum [i]*scale,2);
				cube2[i].renderer.material.color = Color.grey;
			}
			spectrum = mySource.GetSpectrumData(1024, 0, FFTWindow.Rectangular);
			for (int i = 0; i < cube3.Length; i++) {
				cube3 [i].transform.position = new Vector3(i+300, spectrum [i]*scale,3);
				cube3[i].renderer.material.color = Color.yellow;
			}
			yield return null;
		}
	}
}
