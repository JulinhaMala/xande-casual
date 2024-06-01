using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class BestPoint 
{
    private static int pontuacao;
    public static int Pontuacao
    {
        get
        {
            return pontuacao;
        }
        set
        {
            pontuacao = value;
            if (pontuacao < 0)
                pontuacao = 0;

            if (pontuacao > MelhorPontuacao)
            {
                MelhorPontuacao = pontuacao;
            }
        }
    }

    public static int MelhorPontuacao
    {
        get
        {
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        }
        set
        {
            if (value > MelhorPontuacao)
            {
                PlayerPrefs.SetInt("melhorPontuacao", value);
            }
        }
    }



}