using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour {
    const int BAND_LENGTH = 8;
	// Use this for initialization
    AudioSource audioSource;

    public static float[] samples = new float[512];
    public static float[] freqBand = new float[BAND_LENGTH];
    public static float[] bandBuffer = new float[BAND_LENGTH];
    float[] bufferDecrease = new float[BAND_LENGTH];
	void Start () {
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        GetSpectrumData();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumData()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

    }

    void BandBuffer()
    {
        for (int i = 0; i < freqBand.Length; i++)
        {
            if (freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.005f;
            }

            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050/512 = 43Hz per sample
         * 20 - 60 hz */
        
        int count = 0;

        for (int i = 1; i < freqBand.Length; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i);

            if (i == freqBand.Length - 1)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;
        }
    }
}
