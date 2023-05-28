using System.Collections.Generic;
using Model;

namespace Core
{
    public class IngredientsService : AbstractSerializationService
    {
        private List<IngredientType> _ingredients = new();
        

        public List<IngredientType> GetActiveIngredients()
        {
            return _ingredients;
        }

        public void saveIngredients(List<IngredientType> ingredients)
        {
            _ingredients = ingredients;
            Serialize();
        }
        

        override protected string fileName()
        {
            return "Ingredients.dat";
        }

        protected override object objectToSave()
        {
            return _ingredients;
        }

        protected override void handleLoad()
        {
            object deserialized = Deserialize<List<IngredientType>>();
            if (deserialized != null)
            {
                _ingredients = (List<IngredientType>)deserialized;
            }
            else
            {
                _ingredients = new();
            }
        }
    }
}