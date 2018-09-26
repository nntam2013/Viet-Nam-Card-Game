using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGameWF
{
    class GameLaw
    {
        /// <summary>
        /// check tới trắng
        /// </summary>
        /// <param name="MyListCard"></param>
        /// <returns></returns>
        public bool CheckWinTotally(ListCard MyListCard)
        {
            ListCard tam = new ListCard();
            tam = MyListCard;
            // check tứ quý heo
            int heo = 0;
            for (int i = 0; i < 13; i++)
            {
                if (MyListCard.GetCardAt(i).Value == 15) // tối ưu
                {
                    heo++;
                }
            }
            if (heo == 4)
            {
                return true;
            }
            // check sảnh rồng 12 lá
            else
            {
                int doi = 0;
                int vt = 0;
                for (int i = 0; i < 13; i++)
                {
                    if (MyListCard.GetCardAt(i).Value == MyListCard.GetCardAt(i + 1).Value)
                    {
                        doi++;
                        vt = i;
                        if (doi >= 2)
                        { return false; }
                    }

                }
                // nếu có 2 ở cuối
                if (tam.GetCardAt(12).Value == 15)
                {
                    tam.RemovedCardAt(12);
                }
                if (CheckConsecutive(tam) == true)
                {
                    return true;
                }
                // có 1 đôi
                if (doi == 1)
                {
                    tam.RemovedCardAt(vt);
                }
                if (CheckConsecutive(tam) == true && tam.CountCards() == 12)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// check đôi phù hợp hay k. vd 3,3 true ; 3,5 false
        /// </summary>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        ///
        bool CheckDualCard(ListCard selectedCards)
        {
            if (selectedCards.GetCardAt(0).Value == selectedCards.GetCardAt(1).Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// check 3 lá giống nhau vd 3,3,3 true ; 3,5,6 false
        /// </summary>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool CheckThreeSame(ListCard selectedCards)
        {
            return selectedCards.GetCardAt(0).Value == selectedCards.GetCardAt(1).Value && selectedCards.GetCardAt(2).Value == selectedCards.GetCardAt(1).Value;
        }
        /// <summary>
        /// kiem tra listcard co phai la doi thong hay k
        /// </summary>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool Check_doi_thong(ListCard selectedCards)
        {
            selectedCards.Sort();
            int Count = selectedCards.CountCards();
            if (!(selectedCards.GetCardAt(0).Value == selectedCards.GetCardAt(1).Value))
            {
                return false;
            }
            for (int i = 2; i < Count; i = i + 2)
            {


                if (selectedCards.GetCardAt(i).Value == selectedCards.GetCardAt(i + 1).Value)
                {
                    if (selectedCards.GetCardAt(i).Value - selectedCards.GetCardAt(i - 1).Value != 1)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        /// <summary>
        /// kiem tra listcard co phai laf 1 sanh hay k
        /// </summary>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool CheckConsecutive(ListCard selectedCards)
        {
            selectedCards.Sort();
            int count = selectedCards.CountCards();
            if (selectedCards.GetCardAt(count - 1).Value == 15)
            {
                return false;
            }
            for (int i = 0; i < count - 1; i++)
            {
                if (selectedCards.GetCardAt(i).Value - selectedCards.GetCardAt(i + 1).Value != -1)
                {

                    return false;
                }
            }
            return true;
        }
        bool CheckFourCardSame(ListCard selectedCards)
        {
            for (int i = 0; i < 3; i++)
            {
                if (selectedCards.GetCardAt(i).Value != selectedCards.GetCardAt(i + 1).Value)
                {
                    return false;
                }
            }
            return true;
        }
        bool OneCard(ListCard opponentCards, ListCard selectedCards)
        {
            if (opponentCards.GetCardAt(0).Value < selectedCards.GetCardAt(0).Value)
            {
                return true;
            }
            else if (opponentCards.GetCardAt(0).Value == selectedCards.GetCardAt(0).Value)
            {
                if (opponentCards.GetCardAt(0).Power < selectedCards.GetCardAt(0).Power)
                {
                    return true;
                }
            }
            return false;
        }

        bool CompareDualCard(ListCard opponentCards, ListCard selectedCards)
        {
            return selectedCards.GetCardAt(1).CompareTo(opponentCards.GetCardAt(1)) == 1;
        }
        /// <summary>
        /// check 3 la , vd 3 con 5 < 3 con 6
        /// </summary>
        /// <param name="opponentCards"></param>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool ThreeCard(ListCard opponentCards, ListCard selectedCards)
        {
            selectedCards.Sort();
            opponentCards.Sort();
            if (opponentCards.GetCardAt(0).Value < selectedCards.GetCardAt(0).Value)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// de tu quy . vd tu quy 3 < tu quy 4
        /// </summary>
        /// <param name="opponentCards"></param>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool BiggerFourCardSame(ListCard opponentCards, ListCard selectedCards)
        {
            if (opponentCards.GetCardAt(0).Value < selectedCards.GetCardAt(0).Value)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// check sanh danh ra co hop le hay k
        /// </summary>
        /// <param name="opponentCards"></param>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        bool Consecutive(ListCard opponentCards, ListCard selectedCards)
        {
            selectedCards.Sort();
            opponentCards.Sort();
            int i = opponentCards.CountCards() - 1;
            if (opponentCards.GetCardAt(i).Value < selectedCards.GetCardAt(i).Value)
            {
                return true;
            }
            else if (opponentCards.GetCardAt(i).Value == selectedCards.GetCardAt(i).Value)
            {
                if (opponentCards.GetCardAt(i).Power < selectedCards.GetCardAt(i).Power)
                {
                    return true;
                }
            }
            return false;
        }
        bool BiggerPig(ListCard selectedCards)
        {
            if (selectedCards.CountCards() == 4)
            {
                if (CheckFourCardSame(selectedCards) == true)
                {
                    return true;
                }
            }
            // 3,4,5 doi thong
            else // if(selectedCards.CountCards()==6 || selectedCards.CountCards()==8 || selectedCards.CountCards()==10)
            {
                if (Check_doi_thong(selectedCards) == true)
                {
                    return true;
                }
            }
            return false;
        }
        bool BiggerDualPig(ListCard selectedCards)
        {
            if (selectedCards.CountCards() == 4)
            {
                if (CheckFourCardSame(selectedCards) == true)
                {
                    return true;
                }
            }
            else
            {
                if (Check_doi_thong(selectedCards) == true)
                {
                    return true;
                }
            }
            return false;
        }
        bool Chat_doi_thong(ListCard opponentCards, ListCard selectedCards)
        {
            if (Check_doi_thong(selectedCards) == true)
            {
                if (opponentCards.CountCards() < selectedCards.CountCards())
                {
                    return true;
                }
                else if (opponentCards.CountCards() == selectedCards.CountCards())
                {
                    opponentCards.Sort();
                    selectedCards.Sort();
                    if (selectedCards.GetCardAt(selectedCards.CountCards() - 1).Value == opponentCards.GetCardAt(opponentCards.CountCards() - 1).Value)
                    {
                        if (selectedCards.GetCardAt(selectedCards.CountCards() - 1).Power > opponentCards.GetCardAt(selectedCards.CountCards() - 1).Power)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
            // tu quy chat doi thong
        }
        /// <summary>
        /// xử lí đánh tự do
        /// </summary>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        public bool ValidateCards(ListCard selectedCards)
        {
            int count = selectedCards.CountCards();
            selectedCards.Sort();
            if (count == 1)
            {
                return true;
            }
            else if (count == 2)
            {
                if (CheckDualCard(selectedCards) == true)
                {
                    return true; // nếu k phải đánh đầu tiên thì đánh gì cũng dc
                }
                return false; // nếu k phải 1 đôi thì false
            }
            else if (count == 3)
            {
                if (CheckThreeSame(selectedCards))
                {
                    return true;
                }
                else
                {
                    if (CheckConsecutive(selectedCards) == true)
                    {
                        return true;
                    }
                }
                return false; // nếu k phải sảnh or 3 lá giống nhau
            }
            else if (count == 4)
            {
                if (CheckFourCardSame(selectedCards) == true)
                {
                    return true;
                }
                else
                {
                    if (CheckConsecutive(selectedCards) == true)
                    {
                        return true;
                    }
                }
                return false; //nếu k phải tứ quý or sảnh 4
            }
            else if (count == 5 || count == 7 || count == 9 || count == 11)
            {
                if (CheckConsecutive(selectedCards) == true)
                {
                    return true;
                }
                return false; // nếu k phải sảnh
            }
            else if (count == 6 || count == 8 || count == 10)
            {
                if (CheckConsecutive(selectedCards) == true)
                {
                    return true;
                }
                else
                {
                    if (Check_doi_thong(selectedCards) == true)
                    {
                        return true;
                    }
                }
                return false; // nếu k phải sảnh or đôi thông
            }
            return false; // nếu số bài đánh ra là >= 12 lá . vì 12 lá chỉ có sảnh or 6 đôi  là trường hợp tới trắng 
        }

        /// <summary>
        /// check logic 
        /// </summary>
        /// <param name="opponentCards"></param>
        /// <param name="selectedCards"></param>
        /// <returns></returns>
        public bool CheckRules(ListCard opponentCards, ListCard selectedCards)
        {
            int opponentCount = opponentCards.CountCards();
            int selectedCount = selectedCards.CountCards();
            // đánh 1 lá bình thường
            if (opponentCount == 1 && selectedCount == 1)
            {
                //if (OneCard(opponentCards, selectedCards) == true)
                //{
                //    return true;
                //}
                if (selectedCards.GetCardAt(0).CompareTo(opponentCards.GetCardAt(0)) == 1)
                {
                    return true;
                }
            }
            // chat 1 con heo
            else if ((opponentCount == 1 && opponentCards.GetCardAt(0).Value == 15) && (selectedCount == 4 || selectedCount == 6 || selectedCount == 8 || selectedCount == 10))
            {
                if (BiggerPig(selectedCards) == true)
                    return true;
            }
            else if (opponentCount == 2 && selectedCount == 2)
            {

                if (CheckDualCard(selectedCards) == true)
                {
                    //    if (CompareDualCard(opponentCards, selectedCards) == true)
                    //    {
                    //        return true;
                    //    }
                    return selectedCards.GetCardAt(1).CompareTo(opponentCards.GetCardAt(1)) == 1;
                }
            }
            // tứ quý , 3,4,5 đôi thông chặt heo
            else if (opponentCount == 2 && (selectedCount == 4 || selectedCount == 8 || selectedCount == 10))
            {
                if (opponentCards.GetCardAt(0).Value == 15)// heo
                {
                    if (BiggerDualPig(selectedCards) == true)
                        return true;
                }
            }
            else if (opponentCount == 3 && selectedCount == 3)
            {
                if (CheckThreeSame(selectedCards) == true && CheckThreeSame(opponentCards) == true)
                {
                    if (ThreeCard(opponentCards, selectedCards) == true)
                    {
                        return true;
                    }
                }
                else if (CheckConsecutive(selectedCards) == true && CheckConsecutive(opponentCards) == true)
                {
                    if (Consecutive(opponentCards, selectedCards) == true)
                    {
                        return true;
                    }
                }
            }
            // sảnh hoặt 4 quý
            else if (opponentCount == 4 && (selectedCount == 4 || selectedCount == 8 || selectedCount == 10))
            {
                if (CheckFourCardSame(opponentCards) == true)
                {
                    if (selectedCount == 4 && CheckFourCardSame(selectedCards) == true)
                    {
                        if (BiggerFourCardSame(opponentCards, selectedCards) == true)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    if (CheckConsecutive(selectedCards) == true && selectedCards.CountCards() == 4)
                    {
                        if (Consecutive(opponentCards, selectedCards) == true)
                        {
                            return true;
                        }
                    }
                }
            }
            // sảnh 5 ,7,9,11 lá
            else if ((opponentCount == 5 || opponentCount == 7 || opponentCount == 9 || opponentCount == 11) && (selectedCount == 5 || selectedCount == 7 || selectedCount == 9 || selectedCount == 11))
            {
                if (CheckConsecutive(selectedCards) == true && selectedCards.CountCards() == opponentCards.CountCards())
                {
                    if (Consecutive(opponentCards, selectedCards) == true)
                    {
                        return true;
                    }
                }
            }
            // sảnh 6,8,10 lá hoặt 3,4,5 đôi thông
            else if ((opponentCount == 6 || opponentCount == 8 || opponentCount == 10) || (selectedCount == 6 || selectedCount == 8 || selectedCount == 10))
            {
                if (Check_doi_thong(opponentCards) == true)
                {
                    if (opponentCount == selectedCount)
                    {
                        if (Check_doi_thong(selectedCards) == true)
                        {
                            if (Chat_doi_thong(opponentCards, selectedCards) == true)
                                return true;
                        }
                    }
                    if (opponentCount < selectedCount)
                    {
                        if (Check_doi_thong(selectedCards) == true)
                        {
                            if (Chat_doi_thong(opponentCards, selectedCards) == true)
                                return true;
                        }
                    }
                }
                else
                {
                    if (CheckConsecutive(selectedCards) == true && selectedCards.CountCards() == opponentCards.CountCards())
                    {
                        if (Consecutive(opponentCards, selectedCards) == true)
                        {
                            return true;
                        }
                    }
                }

            }
            // chặt 3 đôi thông
            else if (opponentCount == 6 && selectedCount == 4)
            {
                if (Check_doi_thong(opponentCards) == true && CheckFourCardSame(selectedCards) == true)
                    return true;
            }
            return false;
        }
    }
}


