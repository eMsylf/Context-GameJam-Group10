using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    [TextArea]
    public string m_text;
    public float m_characterInterval;

    private string m_partialText;
    private float m_cumulativeDeltaTime;

    private Text m_label;

    public KeyCode TextSkipKey;

    private int fontSizeStandard = 62;

    private TypeWriterSound TypeWriterSound;
    private AudioSource TypeWriterSFX;

    private void Awake() {
        m_label = GetComponent<Text>();
        TypeWriterSound = GetComponent<TypeWriterSound>();
        //TypeWriterSFX = TypeWriterSound.TypeWriterSFX;
    }

    void Start()
    {
        m_partialText = "";
        m_cumulativeDeltaTime = 0;
        ScaleFontSize();

        TypeWriterSound.PlaySound();
    }

    void Update()
    {
        m_cumulativeDeltaTime += Time.deltaTime;
        while (m_cumulativeDeltaTime >= m_characterInterval && m_partialText.Length < m_text.Length) {
            m_partialText += m_text[m_partialText.Length];
            m_cumulativeDeltaTime -= m_characterInterval;
        }
        m_label.text = m_partialText;

        if (Input.GetKeyDown(TextSkipKey)) {
            m_characterInterval = 0;
        } else m_characterInterval = .05f;

        if (m_text.Length == m_partialText.Length) {
            TypeWriterSound.PauseSound();
        }
        
    }

    void ScaleFontSize() {
        if (m_text.Length > 30) {
            m_label.fontSize = fontSizeStandard / 2;
        }
    }
}
