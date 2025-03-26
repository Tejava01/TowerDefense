using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    [SerializeField] protected CharacterBase[] m_characterPrefabs;
    [SerializeField] protected CharacterData[] m_characterData;
    [SerializeField] protected Transform m_poolPoint;
    [SerializeField] protected int m_poolSize;

    protected Dictionary<int, (int, CharacterData)> m_dicCharacterTable = new Dictionary<int, (int, CharacterData)>();
    protected List<Stack<CharacterBase>> m_listCharacterPool = new List<Stack<CharacterBase>>();

    //-----------------------------------------

    public void DoReturnCharacterPool(int i, CharacterBase character)
    {
        character.gameObject.SetActive(false);
        m_listCharacterPool[i].Push(character);
    }

    //-----------------------------------------

    protected void ProtCharacterTableSetting()
    {
        for (int i = 0; i < m_characterData.Length; i++)
        {
            int characterId = m_characterData[i].Id;
            m_dicCharacterTable.Add(characterId, (i, m_characterData[i]));
        }
    }

    protected void ProtCharacterPoolSetting()
    {
        for (int i = 0; i < m_characterPrefabs.Length; i++)
        {
            Stack<CharacterBase> pool = new Stack<CharacterBase>();
            m_listCharacterPool.Add(pool);

            for (int j = 0; j < m_poolSize; j++)
            {
                CharacterBase character = Instantiate(m_characterPrefabs[i], m_poolPoint);
                character.gameObject.SetActive(false);
                m_listCharacterPool[i].Push(character);
            }
        }
    }

    protected CharacterBase ProtDoPoolNextCharacter(int i)
    {
        CharacterBase nextCharacter = null;
        if (m_listCharacterPool[i].Count == 0)
        {
            nextCharacter = Instantiate(m_characterPrefabs[i], m_poolPoint);
        }
        else
        {
            nextCharacter = m_listCharacterPool[i].Pop();
            nextCharacter.gameObject.SetActive(true);
        }

        return nextCharacter;
    }
}
