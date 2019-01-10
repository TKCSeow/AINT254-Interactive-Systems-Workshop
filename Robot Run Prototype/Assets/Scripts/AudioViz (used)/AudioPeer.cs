using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour {

    //Not used in final build
    //Used for audio visualisation



    const int BAND_LENGTH = 64;
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

    void CreateAudioBands()
    {
        for (int i = 0; i < freqBand.Length; i++)
        {
            //if (freqBand[i] > fre)   
        }
    }

    void GetSpectrumData()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

    }

    void BandBuffer()
    {
        for (int i = 0; i < freqBand.Length; ++i)
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

        for (int i = 0; i < freqBand.Length; i++)
        {
            float average = 0;
            int sampleCount = 0;
            if (freqBand.Length == 8)
            {
                sampleCount = (int)Mathf.Pow(2, i) * 2;

            }
            else if (freqBand.Length == 64)
            {
                sampleCount = 1;

            }

            int power = 0;
            if (freqBand.Length == 8)
            {
                if (i == freqBand.Length - 1)
                {
                    sampleCount += 2;
                }
            }
            else if(freqBand.Length == 64)
            {
                if(i == 16 || i == 32 || i == 40 || i == 48 || i == 56)
                {
                    power++;
                    sampleCount = (int)Mathf.Pow(2, power);
                    if (power == 3)
                    {
                        sampleCount -= 2;
                    }
                }
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;

            if (freqBand.Length == 8)
            {
                freqBand[i] = average * 10;

            }
            else if (freqBand.Length == 64)
            {
                freqBand[i] = average * 80;

            }

        }
    }
}
