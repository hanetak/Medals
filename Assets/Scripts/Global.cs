using UnityEngine;
using System.Collections;

/// グローバル情報
public class Global
{
  /// 初期化
  public static void Init()
  {
    _cost = COST_INIT;
  }

  /// 所持コスト
  // 初期値
  const int COST_INIT = 30;
  static int _cost;
  public static int Cost
  {
    get { return _cost; }
  }
  // コストを増やす
  public static void AddCost(int v)
  {
    _cost += v;
  }
  // コストを使う
  public static void UseCost(int v)
  {
    _cost -= v;
    if (_cost < 0)
    {
      _cost = 0;
    }
  }

}
